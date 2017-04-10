using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace HTGL.Model.Configuration
{

    public class SysDictConfiguration : EntityTypeConfiguration<SysDict>
    {
        public SysDictConfiguration()
        {
            ToTable("Sys_Dict");
            HasKey(u => u.DictId);
            // Ignore(u =>u.xid); 被排除的元素
            // Property(u => u.DbName).HasColumnName("DbName").IsRequired();
            Property(u => u.DictName).IsRequired();
        }
    }

    

}
