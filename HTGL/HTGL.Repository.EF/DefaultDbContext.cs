using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HTGL.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Common;
using HTGL.Model.Configuration;

namespace HTGL.Repository.EF
{
    public class DefaultDbContext : DbContext
    {
        #region Fields
        public DbSet<SysDbBackup> SysDbBackup { get; set; }
        public DbSet<SysDict> SysDict { get; set; }
        public DbSet<SysFunction> SysFunction { get; set; }
        public DbSet<SysLog> SysLog { get; set; }
        public DbSet<SysMenu> SysMenu { get; set; }
        public DbSet<SysMenuFunction> SysMenuFunction { get; set; }
        public DbSet<SysOrganize> SysOrganize { get; set; }
        public DbSet<SysRole> SysRole { get; set; }

        public DbSet<SysUser> SysUser { get; set; }
        public DbSet<SysUserRole> SysUserRole { get; set; }
        public DbSet<SysRoleMenu> SysRoleMenu { get; set; }

        #endregion

        public DefaultDbContext()
            : base("name=DefaultDbContext")
        {
            //实体模型改变时，自动迁移到最新版本
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultDbContext, Migrations.Configuration>());
       
        }

        public DefaultDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }

        public DefaultDbContext(DbConnection existingConnection)
            : base(existingConnection, true) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region TypeConfiguration

            // 区域
            // modelBuilder.Configurations.Add(new BaseAreaConfiguration());
            modelBuilder.Configurations.Add(new SysDbBackupConfiguration());
            modelBuilder.Configurations.Add(new SysDictConfiguration());
            modelBuilder.Configurations.Add(new SysFunctionConfiguration());
            modelBuilder.Configurations.Add(new SysLogConfiguration());
            modelBuilder.Configurations.Add(new SysMenuConfiguration());
            modelBuilder.Configurations.Add(new SysMenuFunctionConfiguration());
            modelBuilder.Configurations.Add(new SysOrganizeConfiguration());
            modelBuilder.Configurations.Add(new SysRoleConfiguration());

            modelBuilder.Configurations.Add(new SysUserConfiguration());
            modelBuilder.Configurations.Add(new SysUserRoleConfiguration());
            modelBuilder.Configurations.Add(new SysRoleMenuConfiguration());
            #endregion

            base.OnModelCreating(modelBuilder);

        }
    }
}
