using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace HTGL.Model.Configuration
{

    public class SysUserRoleConfiguration : EntityTypeConfiguration<SysUserRole>
    {
        public SysUserRoleConfiguration()
        {
            ToTable("Sys_User_Role");
            HasKey(u => u.URId); 

        }
    }



}
