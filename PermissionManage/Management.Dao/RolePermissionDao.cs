using Management.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Management.Dao
{
    public class RolePermissionDao
    {
        /// <summary>
        /// 获取所有角色源码
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IEnumerable<RolePermission> GetAllRolePermission(int roleId)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                return dbcontext.RolePermissions.Where(t => t.RoleID == roleId).ToList();
            }
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="list"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool GrantRolePermission(List<RolePermission> list, int roleId)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                using (DbConnection conn = ((IObjectContextAdapter)dbcontext).ObjectContext.Connection)
                {
                    conn.Open();
                    var tran = conn.BeginTransaction();
                    //执行SQL语句，删除原有权限
                    dbcontext.Database.ExecuteSqlCommand("delete  from  RolePermissions where RoleID=" + roleId);
                    foreach (RolePermission permission in list)
                        dbcontext.RolePermissions.Add(permission);
                    if (dbcontext.SaveChanges() > 0)
                    {
                        tran.Commit();
                        return true;
                    }
                    else
                    {
                        tran.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
