/************************************
 * 描述：尚未添加描述
 * 作者：吴毅
 * 日期：2015/9/8 11:15:26  
*************************************/

using HTGL.Repository.EF;
using System.Data.Entity;

namespace HTGL.Data.DbInitialize
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            //启用自动迁移数据库配置
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultDbContext, Configuration>());
        }
    }
}
