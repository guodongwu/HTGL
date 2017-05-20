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
    public class DepartmentDao
    {
        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Department> GetAllDepartment()
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                return dbcontext.Departments.Where(t => t.IsVisible == true && t.ParentID.HasValue).ToList();
            }
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(Department entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Departments.Add(entity);
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Modify(Department data)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Entry<Department>(data).State = System.Data.Entity.EntityState.Modified;
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="DID">部门权限</param>
        /// <returns></returns>
        public bool Remove(int DID)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                using (DbConnection conn = ((IObjectContextAdapter)dbcontext).ObjectContext.Connection)
                {
                    conn.Open();
                    var tran = conn.BeginTransaction();
                    //执行SQL语句，删除部门
                    string sql = @"delete from UserRoles where UserUID in (SELECT UID from Users where DepartmentDID=@DeptID);
                                   delete from Users where DepartmentDID=@DeptID;
                                   delete from Departments where DID=@DeptID;";

                    if (dbcontext.Database.ExecuteSqlCommand(sql, new SqlParameter[] { new SqlParameter("@DeptID", DID) }) > 0)
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
