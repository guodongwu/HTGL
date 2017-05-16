using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace HTGL.Model.Configuration
{

    public class SysFunctionConfiguration : EntityTypeConfiguration<SysFunction>
    {
        public SysFunctionConfiguration()
        {
            ToTable("Sys_Function");
            HasKey(u => u.FunctionId);
            // Ignore(u =>u.xid); 被排除的元素
            // Property(u => u.DbName).HasColumnName("DbName").IsRequired();
           
            Property(u => u.Name).IsRequired();
            
     
        }
    }

    

}
