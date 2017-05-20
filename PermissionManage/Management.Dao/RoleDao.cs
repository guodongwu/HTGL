using Management.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Management.Dao
{
    public class RoleDao
    {
        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Role> GetAllRole()
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                return dbcontext.Roles.ToList();
            }
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(Role entity)
        {
            using (ManagementDBContext db = new ManagementDBContext())
            {
                db.Roles.Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 更改用户信息
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool Modify(Role entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Entry<Role>(entity).State = EntityState.Modified;
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Remove(Role entity)
        {
            try
            {
                using (ManagementDBContext dbcontext = new ManagementDBContext())
                {
                    using (DbConnection conn = ((IObjectContextAdapter)dbcontext).ObjectContext.Connection)
                    {
                        conn.Open();
                        var tran = conn.BeginTransaction();
                        //执行SQL语句，删除原有权限
                        var sql = "DELETE FROM dbo.UserRoles WHERE RoleRID=@RID;DELETE FROM dbo.RolePermissions WHERE RoleID=@RID";
                        SqlParameter[] param = new SqlParameter[] { new SqlParameter("@RID", entity.RID) };
                        dbcontext.Database.ExecuteSqlCommand(sql, param);
                        dbcontext.Roles.Attach(entity);
                        dbcontext.Entry<Role>(entity).State = EntityState.Deleted;
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
            catch (Exception ex)
            {
                
                throw;
            }
          
        }
    }
}
