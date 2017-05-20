using Management.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.Dao
{
    public class ModulePermissionDao
    {
        /// <summary>
        /// 分页查询(获取菜单权限分页)
        /// </summary>
        /// <param name="pageNumber">当前页</param>
        /// <param name="pageSize">单页显示数量</param>
        /// <param name="sortOrder">排序条件</param>
        /// <param name="controllName">控制器名称</param>
        /// <param name="Number">总记录数</param>
        /// <returns></returns>
        public IEnumerable<ModulePermission> GetModulePermissionForPaging(int pageNumber, int pageSize, string controllName, out int Number)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                var result = from modulepermission in dbcontext.ModulePermissions.Include("Permission").Include("Module")
                             where modulepermission.Permission.PermissionController == controllName &&
                             modulepermission.Module.IsVisible == true && modulepermission.Permission.IsVisible == true
                             select modulepermission;
                Number = result.Count();
                return result.Distinct().OrderBy(t=>t.Permission.Sort).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList<ModulePermission>();
            }
        }

        /// <summary>
        /// 获取所有权限信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModulePermission> GetAllPermission()
        {
            using (ManagementDBContext dbcontext=new ManagementDBContext())
            {
                var result = from modulePermission in dbcontext.ModulePermissions.Include("Permission").Include("Module")
                             where modulePermission.Module.IsVisible == true && modulePermission.Permission.IsVisible == true
                             orderby modulePermission.Module.ModuleController
                             select modulePermission;
                return result.ToList();
            }  
        }

        /// <summary>
        /// 添加菜单按钮
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(ModulePermission entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.ModulePermissions.Add(entity);
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 修改菜单按钮
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Modify(ModulePermission entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Entry<ModulePermission>(entity).State = System.Data.Entity.EntityState.Modified;
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 删除菜单按钮
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Remove(ModulePermission entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.ModulePermissions.Attach(entity);
                dbcontext.ModulePermissions.Remove(entity);
                return dbcontext.SaveChanges() > 0;
            }
        }
    }
}