using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace HTGL.Model.Configuration
{

    public class SysRoleMenuConfiguration: EntityTypeConfiguration<SysRoleMenu>
    {
        public SysRoleMenuConfiguration()
        {
            ToTable("Sys_Role_Menu");
            HasKey(u => u.RMId);
            // Ignore(u =>u.xid); 被排除的元素
            // Property(u => u.DbName).HasColumnName("DbName").IsRequired();
            Property(u => u.MenuId).IsRequired();

        }
    }

    

}
