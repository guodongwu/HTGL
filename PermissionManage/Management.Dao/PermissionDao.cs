using Management.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Management.Dao
{
    public class PermissionDao
    {
        /// <summary>
        /// 分页查询(获取权限分页)
        /// </summary>
        /// <param name="pageNumber">当前页</param>
        /// <param name="pageSize">单页显示数量</param>
        /// <param name="sortOrder">排序条件</param>
        /// <param name="controllName">控制器名称</param>
        /// <param name="Number">总记录数</param>
        /// <returns></returns>
        public IEnumerable<Permission> GetPermissionForPaging(int pageNumber, int pageSize, string controllName, out int Number)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                var result = from permission in dbcontext.Permissions
                             where permission.PermissionController == controllName && permission.IsVisible == true
                             select permission;
                Number = result.Count();
                return result.Distinct().OrderBy(t => t.PID).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList<Permission>();
            }
        }

        /// <summary>
        /// 分页查询(获取权限分页)
        /// </summary>
        /// <param name="pageNumber">当前页</param>
        /// <param name="pageSize">单页显示数量</param>
        /// <param name="sortOrder">排序条件</param>
        /// <param name="Number">总记录数</param>
        /// <returns></returns>
        public IEnumerable<Permission> GetPermissionForPaging()
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                var result = from permission in dbcontext.Permissions
                             //where permission.IsVisible == true
                             select permission;
                return result.Distinct().ToList<Permission>();
            }
        }

        /// <summary>
        /// 新增权限
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(Permission entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Permissions.Add(entity);
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Modify(Permission entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Entry<Permission>(entity).State = System.Data.Entity.EntityState.Modified;
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="PID">权限ID</param>
        /// <returns></returns>
        public bool Remove(int PID)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                using (DbConnection conn = ((IObjectContextAdapter)dbcontext).ObjectContext.Connection)
                {
                    conn.Open();
                    var tran = conn.BeginTransaction();
                    //执行SQL语句，删除权限
                    string sql = @"delete from RolePermissions where ModulePermissionID in (select ModulePermissionID from ModulePermissions where PermissionPId=@PermissionID);
                                   delete from dbo.ModulePermissions where PermissionPId=@PermissionID;
                                   delete from Permissions where PID=@PermissionID;";

                    if (dbcontext.Database.ExecuteSqlCommand(sql, new SqlParameter[] { new SqlParameter("@PermissionID", PID) }) > 0)
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
