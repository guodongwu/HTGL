using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace HTGL.Model.Configuration
{

    public class SysDepartmentConfiguration : EntityTypeConfiguration<SysDepartment>
    {
        public SysDepartmentConfiguration()
        {
            ToTable("Sys_Department");
 
        }
    }

    

}
