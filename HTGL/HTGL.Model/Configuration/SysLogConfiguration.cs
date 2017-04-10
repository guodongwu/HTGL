using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace HTGL.Model.Configuration
{

    public class SysLogConfiguration : EntityTypeConfiguration<SysLog>
    {
        public SysLogConfiguration()
        {
            ToTable("Sys_Log");
            HasKey(u => u.LogId);
            // Ignore(u =>u.xid); 被排除的元素
            // Property(u => u.DbName).HasColumnName("DbName").IsRequired();
        }
    }

    

}
