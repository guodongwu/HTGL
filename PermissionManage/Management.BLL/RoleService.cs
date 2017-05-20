using Management.Dao;
using Management.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Management.Entity;

namespace Management.BLL
{
    public class RoleService
    {
        RoleDao dao = null;
        public RoleService()
        {
            dao = new RoleDao();
        }
        /// <summary>
        /// 获取角色树
        /// </summary>
        /// <param name="requestTree">Tree请求</param>
        /// <param name="AdminRoleId">管理员角色ID</param>
        /// <returns></returns>
        public IEnumerable<UITree> GetRoleTree(UITreeRequest requestTree, int AdminRoleId)
        {
            //返回ui层的菜单
            var data = dao.GetAllRole().Where(t => t.RID != AdminRoleId).Distinct().ToList();
            IEnumerable<UITree> rootRole = new List<UITree>(){
            new UITree(){icon = requestTree.RootIcon,id=0,desc="角色组",text = "角色组",children = (List<UITree>)UITree.ToListViewModel(data)}};
            return rootRole;
        }

        /// <summary>
        /// 获取角色树
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UITree> GetRolesForSelect()
        {
            return UITree.ToListViewModel(dao.GetAllRole());
        }

        /// <summary>
        /// 获取请求的角色列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <param name="Count">总记录数</param>
        /// <returns></returns>
        public UIGrid GetAllRoles()
        {
            return new UIGrid() { Rows = dao.GetAllRole() };
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(Role entity)
        {
            return dao.Add(entity);
        }

        /// <summary>
        /// 更改用户信息
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool Update(Role entity)
        {
            return dao.Modify(entity);
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(Role entity)
        {
            return dao.Remove(entity);
        }
    }
}
