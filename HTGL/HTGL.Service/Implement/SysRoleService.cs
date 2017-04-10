using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HTGL.Service;
using HTGL.Service.Interface;
using HTGL.Data.Repositories;

namespace HTGL.Service.Implement
{
    public class SysRoleService : BaseService, ISysRoleService
    {


        private readonly ISysRoleRepository _sysRoleRepository;
        public SysRoleService(ISysRoleRepository sysRoleRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _sysRoleRepository = sysRoleRepository;
        }
        public IQueryable<SysRole> SysRoles
        {
            get { return _sysRoleRepository.Entities; }
        }

        public OperationResult Add(SysRole sysRole)
        {
            try
            {
                var entity = SysRoles.FirstOrDefault(c => c.Name == sysRole.Name.Trim());
                if (entity != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的模块，请修改后重新提交！");
                }
                entity = new SysRole
                {
                    Name = sysRole.Name.Trim(),
                    AddTime = DateTime.Now,
                };
                _sysRoleRepository.Insert(entity);
                return new OperationResult(OperationResultType.Success, "新增数据成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增数据失败，数据库插入数据时发生了错误!");
            }
        }

        public OperationResult Remove(SysRole sysRole)
        {
            _sysRoleRepository.Delete(sysRole);
            return new OperationResult(OperationResultType.Success, "删除数据成功！");
        }

        public OperationResult Save(SysRole sysRole)
        {
            _sysRoleRepository.Update(sysRole);
            return new OperationResult(OperationResultType.Success, "修改数据成功！");
        }

        public SysRole FindBy(Func<SysRole, bool> where)
        {
            return SysRoles.FirstOrDefault(where);
        }


        public List<SysRole> FindAll()
        {
            return SysRoles.ToList();
        }

        public List<SysRole> FindAll(Func<SysRole, bool> where)
        {
            return SysRoles.Where(where).ToList();
        }

        public List<SysRole> FindAll<Tkey>(Func<SysRole, bool> where, Func<SysRole, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            total = SysRoles.Where(where).Count();
            return SysRoles.Where(where).OrderByDescending(orderbyLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

        }
    }
}

