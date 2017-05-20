using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTGL.Repository.EF;
using HTGL.Data.Repositories;
using HTGL.Component.Tools;
using HTGL.Service.Interface;

namespace HTGL.Service.Implement
{
    public class SysDepartmentService : BaseService, ISysDepartmentService
    {

        private readonly ISysDepartmentRepository _sysDepartmentRepository;
        public SysDepartmentService(ISysDepartmentRepository sysDepartmentRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _sysDepartmentRepository = sysDepartmentRepository;
        }

        public IQueryable<SysDepartment> SysDepartments
        {
            get
            {
                return _sysDepartmentRepository.Entities;
            }
        }

        public OperationResult Add(SysDepartment sysDepartment)
        {
            try
            {
                var entity = SysDepartments.FirstOrDefault(c => c.DeptName == sysDepartment.DeptName.Trim());
                if (entity != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的模块，请修改后重新提交！");
                }
                _sysDepartmentRepository.Insert(sysDepartment);
                return new OperationResult(OperationResultType.Success, "新增数据成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增数据失败，数据库插入数据时发生了错误!");
            }
        }

        public List<SysDepartment> FindAll()
        {
            return SysDepartments.ToList();
        }

        public List<SysDepartment> FindAll(Func<SysDepartment, bool> where)
        {
            return SysDepartments.Where(where).ToList();
        }

        public List<SysDepartment> FindAll<Tkey>(Func<SysDepartment, bool> where, Func<SysDepartment, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            total = SysDepartments.Where(where).Count();
            return SysDepartments.Where(where).OrderByDescending(orderbyLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public SysDepartment FindBy(Func<SysDepartment, bool> where)
        {
            return SysDepartments.FirstOrDefault(where);
        }

        public OperationResult Remove(SysDepartment sysDepartment)
        {
            _sysDepartmentRepository.Delete(sysDepartment);
            return new OperationResult(OperationResultType.Success, "删除数据成功！");
        }

        public OperationResult Save(SysDepartment sysDepartment)
        {
            _sysDepartmentRepository.Update(sysDepartment);
            return new OperationResult(OperationResultType.Success, "修改数据成功！");
        }


        public string GetDepartmentGridTree()
        {
            int total = 0;
            IEnumerable<SysDepartment> departAllList = _sysDepartmentRepository.Entities.Where(t => t.IsVisible == true && t.ParentId.HasValue).ToList();
            List<UITree> listDepart = new List<UITree>();
            //查找所有的一级部门
            var ParentDepart = departAllList.Where(con => con.ParentId.Value == 0);
            foreach (var parent in ParentDepart)
            {
                //实体转化 
                UITree parentItem = UITree.ToEntity(parent);
                //获取子级
                GetDepartmentChildren(ref parentItem, (List<SysDepartment>)departAllList);
                listDepart.Add(parentItem);
            }
            //grid数据输出
            UIGrid grid = new UIGrid();
            grid.Rows = listDepart;
            grid.Total = total;
            return JSONHelper.ToJson(grid, true);
        }
        /// <summary>
        /// 获取父级部门下的子部门列表信息
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="allList"></param>
        /// <returns></returns>
        private void GetDepartmentChildren(ref UITree parent, List<SysDepartment> allList)
        {
            foreach (SysDepartment depart in allList)
            {
                if (depart.ParentId.HasValue && depart.ParentId.Value == parent.id)
                {
                    //实体转化
                    UITree child = UITree.ToEntity(depart);
                    if (parent.children == null)
                        parent.children = new List<UITree>();
                    //添加到父级的Children中
                    parent.children.Add(child);
                    GetDepartmentChildren(ref child, allList);//递归添加子树
                }
            }
        }
    }
}
