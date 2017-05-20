using Management.Dao;
using Management.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.BLL
{
    public class UserRoleService
    {
        UserRoleDao dao = null;
        public UserRoleService()
        {
            dao = new UserRoleDao();
        }
        /// <summary>
        /// 根据用户ID获取用户所有角色
        /// </summary>
        /// <param name="UID">用户ID</param>
        /// <returns></returns>
        public IEnumerable<UserRole> GetUserRole(int UID)
        {
            return dao.GetUserRole(UID);
        }
    }
}
