using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Management.Entity;

namespace Management.Dao
{
    public class ManagementDBContextInitializer : DropCreateDatabaseAlways<ManagementDBContext>
    {
        protected override void Seed(ManagementDBContext context)
        {
            base.Seed(context);
            //var roles = new List<Role>
            //{
            //    new Role{
            //        RoleName="超级管理员",
            //        Description="Administrator"
            //    },
            //    new Role{
            //        RoleName="普通管理员",
            //        Description="Admin"
            //    }
            //};
            //roles.ForEach(l => context.Roles.Add(l));
            context.SaveChanges();
        }
    }
}
