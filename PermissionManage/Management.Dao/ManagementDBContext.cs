using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Entity;

namespace Management.Dao
{
    public class ManagementDBContext : DbContext
    {
        public ManagementDBContext()
            : base("ManagementConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ManagementDBContext>());
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModulePermission> ModulePermissions { get; set; }
        public DbSet<OperateLog> OperateLogs { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<PublicDictionary> PublicDictionarys { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
