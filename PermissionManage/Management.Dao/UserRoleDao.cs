using Management.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.Dao
{
    public class UserRoleDao
    {
        /// <summary>
        /// 根据用户ID获取用户所有角色
        /// </summary>
        /// <param name="UID">用户ID</param>
        /// <returns></returns>
        public IEnumerable<UserRole> GetUserRole(int UID)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                return dbcontext.UserRoles.Where(t => t.UserUID == UID).ToList();
            }
        }
    }
}
