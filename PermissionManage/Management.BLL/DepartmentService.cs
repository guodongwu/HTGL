using Management.Dao;
using Management.Entity;
using Management.Tools;
using Management.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.BLL
{
    public class DepartmentService
    {
        DepartmentDao dao = null;
        public DepartmentService()
        {
            dao = new DepartmentDao();
        }
        #region 获取部门GridTree的json格式数据
        /// <summary>
        /// 获取部门GridTree的json格式数据
        /// </summary>
        /// <returns></returns>
        public string GetDepartmentGridTree()
        {
            int total = 0;
            IEnumerable<Department> departAllList = dao.GetAllDepartment();
            List<UITree> listDepart = new List<UITree>();
            //查找所有的一级部门
            var ParentDepart = departAllList.Where(con => con.ParentID.Value == 0);
            foreach (var parent in ParentDepart)
            {
                //实体转化 
                UITree parentItem = UITree.ToEntity(parent);
                //获取子级
                GetDepartmentChildren(ref parentItem, (List<Department>)departAllList);
                listDepart.Add(parentItem);
            }
            //grid数据输出
            UIGrid grid = new UIGrid();
            grid.Rows = listDepart;
            grid.Total = total;
            return JSONHelper.ToJson(grid, true);
        }

        /// <summary>
        /// 获取部门的Tree格式
        /// </summary>
        /// <param name="treeData">获得树级请求数据</param>
        /// <returns></returns>
        public IEnumerable<UITree> GetDepartmentTree(UITreeRequest treeData)
        {
            StringBuilder sbJson = new StringBuilder();
            IEnumerable<Department> departAllList = dao.GetAllDepartment();
            List<UITree> listDepart = new List<UITree>();
            //查找所有的一级部门
            var ParentDepart = departAllList.Where(con => con.ParentID.Value == 0);

            foreach (var parent in ParentDepart)
            {
                //实体转化 
                UITree parentItem = UITree.ToEntity(parent);
                //获取子级
                GetDepartmentChildren(ref parentItem, (List<Department>)departAllList);
                listDepart.Add(parentItem);
            }
            return listDepart;

        }
        #endregion
        /// <summary>
        /// 获取父级部门下的子部门列表信息
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="allList"></param>
        /// <returns></returns>
        private void GetDepartmentChildren(ref UITree parent, List<Department> allList)
        {
            foreach (Department depart in allList)
            {
                if (depart.ParentID == parent.id)
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

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(Department entity)
        {
            return dao.Add(entity);
        }

        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(Department data)
        {
            return dao.Modify(data);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="DID">部门ID</param>
        /// <returns></returns>
        public bool Delete(int DID)
        {
            return dao.Remove(DID);
        }
    }
}
