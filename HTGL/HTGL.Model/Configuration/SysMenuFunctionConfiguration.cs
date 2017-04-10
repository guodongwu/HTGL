using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace HTGL.Model.Configuration
{

    public class SysMenuFunctionConfiguration : EntityTypeConfiguration<SysMenuFunction>
    {
        public SysMenuFunctionConfiguration()
        {
            ToTable("Sys_Menu_Function");
            //HasKey(u => u.);
            // Ignore(u =>u.xid); 被排除的元素
            // Property(u => u.DbName).HasColumnName("DbName").IsRequired();
            HasKey(u => u.MFId);
            Property(u => u.FunctionId).IsRequired();
            Property(u => u.MenuId).IsRequired();
            HasRequired(u => u.SysMenu).WithMany().HasForeignKey(u => u.MenuId);
            HasRequired(u => u.SysFunction).WithMany().HasForeignKey(u => u.FunctionId);

        }
    }

    

}
