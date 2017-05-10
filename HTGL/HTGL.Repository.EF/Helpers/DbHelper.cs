using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTGL.Model;


namespace HTGL.Repository.EF
{
    /// <summary>
    /// 数据库访问类
    /// </summary>
    public class DbHelper
    {
        private DbHelper()
        {

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="sql">SQL语句</param>
        /// <param name="parmas">参数</param>
        /// <returns>返回实体列表</returns>
        public static IList<T> Query<T>(string sql, params object[] parmas)
        {
            return DataContextFactory.GetCurrentDbContext().Database.SqlQuery<T>(sql, parmas).ToList();
        }

        /// <summary>
        ///    查询第一行（top 1） 
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="sql">SQL语句</param>
        /// <param name="parmas">  @p0 点位符,或者命名参数</param>
        /// <returns>返回实体</returns>
        public static T First<T>(string sql, params object[] parmas)
        {
            return DataContextFactory.GetCurrentDbContext().Database.SqlQuery<T>(sql, parmas).FirstOrDefault();
        }

        /// <summary>
        ///    查询第一行
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="sql">SQL语句</param>
        /// <param name="parmas">  @p0 点位符,或者命名参数</param>
        /// <returns>返回实体</returns>
        public static T Single<T>(string sql, params object[] parmas)
        {
            return DataContextFactory.GetCurrentDbContext().Database.SqlQuery<T>(sql, parmas).SingleOrDefault();
        }

        /// <summary>
        ///    执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parmas">  @p0 点位符,或者命名参数</param>
        /// <returns>返回操作结果</returns>
        public static int Execute(string sql, params object[] parmas)
        {

            return DataContextFactory.GetCurrentDbContext().Database.ExecuteSqlCommand(sql, parmas);
        }

        public static bool Execute(SysLog syslog)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"INSERT INTO [Sys_Log](
            [UserId]
           ,[UserName]
           ,[OperatingType]
           ,[OperatingTime]
           ,[Event]
           ,[OperatingIP]
           ,[MenuId]
           ,[MenuName]
           ,[FunctionId]
           ,[FunctionName]
           ,[OperatingResult]
           ,[OperatingDesc]
           ,[ProcessName]
           ,[ProcessDesc]
           ,[MethodName])");
            strSql.Append("VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14);");
            return DbHelper.Execute(strSql.ToString(), syslog.UserId, syslog.UserName, syslog.OperatingType, syslog.OperatingTime, syslog.Event, syslog.OperatingIp, syslog.MenuId,
                syslog.MenuName, syslog.FunctionId, syslog.FunctionName, syslog.OperatingResult, syslog.OperatingDesc, syslog.ProcessName,
                syslog.ProcessDesc, syslog.MethodName) > 0;
        }

    }
}