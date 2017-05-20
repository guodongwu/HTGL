using Management.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.Dao
{
    public class OperateLogDao
    {
        /// <summary>
        /// 根据月份数删除日志
        /// </summary>
        /// <param name="month">删除的月份数量</param>
        /// <returns></returns>
        public bool DeleteOperateLogByMonth(int month)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                return dbcontext.Database.ExecuteSqlCommand("delete from OperateLogs where DATEADD(MONTH," + month + ",CreateDate)<getdate()") > 0;
            }
        }

        /// <summary>
        /// 删除全部日志
        /// </summary>
        /// <returns></returns>
        public bool DeleteOperateLogAll()
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                return dbcontext.Database.ExecuteSqlCommand("delete from OperateLogs") > 0;
            }
        }

        /// <summary>
        /// 删除单个日志
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteOperateLogEntity(OperateLog entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.OperateLogs.Attach(entity);
                dbcontext.OperateLogs.Remove(entity);
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertOperateLog(OperateLog entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.OperateLogs.Add(entity);
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 分页查询(获取菜单分页)
        /// </summary>
        /// <param name="endDt">结束时间</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="startDt">开始时间</param>
        /// <param name="userName">用户名</param>
        /// <param name="pageNumber">当前页</param>
        /// <param name="pageSize">单页显示数量</param>
        /// <param name="sortOrder">排序条件</param>
        /// <param name="parentNo">父级编号</param>
        /// <param name="Number">总记录数</param>
        /// <returns></returns>
        public IEnumerable<OperateLog> GetOperateLogsForPaging(string userName, string ipAddress, DateTime? startDt, DateTime? endDt, int pageNumber, int pageSize, out int Number)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                //ManagementDBContext dbcontext = new ManagementDBContext();
                var result = from module in dbcontext.OperateLogs.Include("User") select module;
                //查询
                if (!String.IsNullOrEmpty(userName))
                    result = result.Where(t => t.UserName.Contains(userName));
                if (!String.IsNullOrEmpty(ipAddress))
                    result = result.Where(t => t.IPAddress == ipAddress);
                if (startDt != null)
                    result = result.Where(t => t.CreateDate >= startDt);
                if (endDt != null)
                    result = result.Where(t => t.CreateDate <= endDt);
                Number = result.Count();
                return result.Distinct().OrderBy(p => p.OID).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList<OperateLog>();
            }
        }

        /// <summary>
        /// 根据ID获取日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperateLog GetOperateLogByID(int id)
        {
            using (ManagementDBContext db = new ManagementDBContext())
            {
                return db.OperateLogs.Where(t => t.OID == id).FirstOrDefault();
            }
        }
    }
}
