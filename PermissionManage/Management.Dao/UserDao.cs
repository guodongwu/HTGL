using Management.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Management.Dao
{
    public class UserDao
    {
        #region 用户信息
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginName">登陆姓名</param>
        /// <param name="loginPwd">登陆密码</param>
        /// <returns></returns>
        public User Login(string loginName, string loginPwd)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                return dbcontext.Users.Where(t => t.UserName == loginName && t.UserPassword == loginPwd && t.IsVisible == true).SingleOrDefault();
            }
        }

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="uID"></param>
        /// <returns></returns>
        public User GetUserInfoByUID(int uID)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                return dbcontext.Users.Where(t => t.UID == uID).SingleOrDefault();
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool ChangePassword(User entity, string password)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                entity.UserPassword = password;
                entity.LastLoginTime = DateTime.Now;
                dbcontext.Entry(entity).State = EntityState.Modified;
                return dbcontext.SaveChanges() > 0;
            }
        }
        #endregion

        #region 权限校验
        /// <summary>
        /// 角色是否拥有该操作权限
        /// </summary>
        /// <param name="roles">角色组</param>
        /// <param name="controller">控制器</param>
        /// <param name="action">动作</param>
        /// <returns></returns>
        public bool RoleHasOperatePermission(List<int> roles, string controller, string action)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                var result = from module in dbcontext.Modules
                             join modulepermission in dbcontext.ModulePermissions on module.MID equals modulepermission.ModuleMId
                             join permission in dbcontext.Permissions on modulepermission.PermissionPId equals permission.PID
                             join rolepermission in dbcontext.RolePermissions on modulepermission.MPID equals rolepermission.ModulePermissionID
                             where rolepermission.RoleID.HasValue && roles.Contains(rolepermission.RoleID.Value) && permission.PermissionController == controller && permission.PermissionAction == action
                             select module;
                return result.Count() > 0;
            }
        }
        /// <summary>
        /// 角色是否拥有该菜单模块权限
        /// </summary>
        /// <param name="roles">角色组</param>
        /// <param name="controller">控制器</param>
        /// <returns></returns>
        public bool RoleHasMenusPermission(List<int> roles, string controller)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                var result = from module in dbcontext.Modules
                             join modulepermission in dbcontext.ModulePermissions on module.MID equals modulepermission.ModuleMId
                             join permission in dbcontext.Permissions on modulepermission.PermissionPId equals permission.PID
                             join rolepermission in dbcontext.RolePermissions on modulepermission.MPID equals rolepermission.ModulePermissionID
                             where rolepermission.RoleID.HasValue && roles.Contains(rolepermission.RoleID.Value) && permission.PermissionController == controller && module.IsMenu == true
                             select module;
                return result.Count() > 0;
            }
        }
        #endregion

        #region 用户菜单
        /// <summary>
        /// 根据用户角色获取菜单
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public IEnumerable<Module> GetPermissonMenusByRoles(List<int> roles)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                var result = from rolePermission in dbcontext.RolePermissions
                             join modulePermission in dbcontext.ModulePermissions on rolePermission.RPID equals modulePermission.MPID
                             join module in dbcontext.Modules on modulePermission.ModuleMId equals module.MID
                             where (rolePermission.RoleID.HasValue && roles.Contains(rolePermission.RoleID.Value)) && module.IsVisible == true
                             select module;
                return result.Distinct().ToList();
            }
        }

        /// <summary>
        /// 获取所有有效的菜单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Module> GetAllPermissonMenus()
        {
            using (ManagementDBContext db = new ManagementDBContext())
            {
                return db.Modules.Where(t => t.IsVisible == true && t.IsMenu == true).ToList();
            }
        }
        /// <summary>
        /// 根据角色和控制器获取按钮信息
        /// </summary>
        /// <param name="aoles">角色组</param>
        /// <param name="menuNo">控制器(也就是菜单信息)</param>
        /// <returns></returns>
        public IEnumerable<Permission> GetUserModulePermission(List<int> roles, string menuNo)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                var result = from module in dbcontext.Modules
                             join modulepermission in dbcontext.ModulePermissions on module.MID equals modulepermission.ModuleMId
                             join permission in dbcontext.Permissions on modulepermission.PermissionPId equals permission.PID
                             join rolepermission in dbcontext.RolePermissions.Where(p => p.RoleID.HasValue && roles.Contains(p.RoleID.Value)) on modulepermission.MPID equals rolepermission.ModulePermissionID
                             where permission.PermissionController == menuNo && permission.IsButton == true && permission.IsVisible == true
                             orderby permission.Sort
                             select permission;
                return result.Distinct().ToList();
            }
        }

        /// <summary>
        /// 根据控制器获取按钮信息
        /// </summary>
        /// <param name="menuNo">控制器</param>
        /// <returns></returns>
        public IEnumerable<Permission> GetUserModulePermission(string menuNo)
        {
            using (ManagementDBContext db = new ManagementDBContext())
            {
                return db.Permissions.Where(t => t.IsVisible == true && t.PermissionController == menuNo && t.IsButton == true).ToList();
            }
        }

        /// <summary>
        /// 分页查询(获取菜单分页)
        /// </summary>
        /// <param name="pageNumber">当前页</param>
        /// <param name="pageSize">单页显示数量</param>
        /// <param name="sortName">排序名称</param>
        /// <param name="roles">角色组</param>
        /// <param name="parentNo">父级编号</param>
        /// <param name="Number">总记录数</param>
        /// <returns></returns>
        public IEnumerable<Module> GetAllMenusForPaging(int pageNumber, int pageSize, List<int> roles, int parentNo, out int Number)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                var result = from rolePermission in dbcontext.RolePermissions
                             join modulePermission in dbcontext.ModulePermissions on rolePermission.RPID equals modulePermission.MPID
                             join module in dbcontext.Modules on modulePermission.ModuleMId equals module.MID
                             where rolePermission.RoleID.HasValue && roles.Contains(rolePermission.RoleID.Value) && module.ParentID == parentNo
                             && module.IsVisible == true
                             select module;
                Number = result.Count();
                return result.Distinct().OrderBy(t => t.MID).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }

        }

        #endregion

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <param name="pageNumber">当前页</param>
        /// <param name="pageSize">单页显示数量</param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers(int pageNumber, int pageSize, out int count)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                var result = dbcontext.Users;
                count = result.Count();
                return result.Distinct().OrderBy(t => t.UID).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        /// <summary>
        /// 获取用户名对应的数量
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetCount(string userName)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                return dbcontext.Users.Where(t => t.UserName == userName).Count();
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="list">角色ID集合</param>
        /// <returns></returns>
        public bool Add(User entity, List<int> list)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Users.Add(entity);
                dbcontext.SaveChanges();
                int uid = entity.UID;
                if (uid > 0 && list != null && list.Count > 0)
                {
                    List<UserRole> userrole = new List<UserRole>();
                    foreach (var item in list)
                    {
                        userrole.Add(new UserRole() { UserUID = uid, RoleRID = item, CreateUserID = entity.CreateUserID, CreateDate = entity.CreateDate });
                    }
                    dbcontext.UserRoles.AddRange(userrole);
                }
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 更改用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Modify(User entity, List<int> list)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                using (DbConnection conn = ((IObjectContextAdapter)dbcontext).ObjectContext.Connection)
                {
                    conn.Open();
                    var tran = conn.BeginTransaction();
                    //执行SQL语句，删除原有权限
                    dbcontext.Database.ExecuteSqlCommand("DELETE FROM dbo.UserRoles WHERE UserUID=" + entity.UID);
                    List<UserRole> userrole = new List<UserRole>();
                    foreach (var item in list)
                    {
                        userrole.Add(new UserRole() { UserUID = entity.UID, RoleRID = item, CreateUserID = entity.CreateUserID, CreateDate = entity.CreateDate });
                    }
                    dbcontext.UserRoles.AddRange(userrole);
                    dbcontext.Entry<User>(entity).State = EntityState.Modified;
                    if (dbcontext.SaveChanges() > 0)
                    {
                        tran.Commit();
                        return true;
                    }
                    else
                    {
                        tran.Rollback();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 更改用户信息
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool Modify(User entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Entry<User>(entity).State = EntityState.Modified;
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Remove(User entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Users.Attach(entity);
                dbcontext.Users.Remove(entity);
                return dbcontext.SaveChanges() > 0;
            }
        }
    }
}
