using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace HTGL.Model.Configuration
{

    public class SysOrganizeConfiguration : EntityTypeConfiguration<SysOrganize>
    {
        public SysOrganizeConfiguration()
        {
            ToTable("Sys_Organize");
            HasKey(u => u.OrganizeId);
            // Ignore(u =>u.xid); 被排除的元素
            // Property(u => u.DbName).HasColumnName("DbName").IsRequired();
            Property(u => u.FullName).IsRequired();
        }
    }

    

}
