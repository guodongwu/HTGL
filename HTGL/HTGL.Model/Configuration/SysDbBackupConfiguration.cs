using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace HTGL.Model.Configuration
{

    public class SysDbBackupConfiguration : EntityTypeConfiguration<SysDbBackup>
    {
        public SysDbBackupConfiguration()
        {
            ToTable("Sys_DbBackup");
            HasKey(u => u.BackupId);
            // Ignore(u =>u.xid); 被排除的元素
            // Property(u => u.DbName).HasColumnName("DbName").IsRequired();
            Property(u => u.DbName).IsRequired();
        }
    }

    

}
