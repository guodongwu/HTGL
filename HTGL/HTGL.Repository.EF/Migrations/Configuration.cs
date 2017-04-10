using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace HTGL.Repository.EF
{
    internal sealed class Configuration : DbMigrationsConfiguration<DefaultDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        // ��ʼ�����ݿ�������ݵ��õķ���
        protected override void Seed(DefaultDbContext context)
        {
            ////  This method will be called after migrating to the latest version.


        }
    }
}
