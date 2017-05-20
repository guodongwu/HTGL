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
    public class RolePermissionService
    {
        RolePermissionDao dao = null;
        public RolePermissionService()
        {
            dao = new RolePermissionDao();
        }

        /// <summary>
        /// 获取所有角色权限
        /// </summary>
        /// <param name="request"></param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public IEnumerable<RolePermission> GetAllRolePermission(int roleId)
        {
            return dao.GetAllRolePermission(roleId);
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="ModulePermissionIDs"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool GrantRolePermission(string[] ModulePermissionIDs, int roleId)
        {
            List<RolePermission> list = new List<RolePermission>();
            foreach (var ModulePermissionID in ModulePermissionIDs)
            {
                int MPID = -1;
                if (int.TryParse(ModulePermissionID, out MPID))
                {
                    list.Add(new RolePermission()
                    {
                        RoleID = roleId,
                        CreateDate = DateTime.Now,
                        CreateUserID = int.Parse(SessionHelper.Get("UserID")),
                        ModulePermissionID = MPID
                    });
                }
            }
            return dao.GrantRolePermission(list, roleId);
        }
    }
}
