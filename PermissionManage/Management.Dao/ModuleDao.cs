using Management.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.Dao
{
    public class ModuleDao
    {
        /// <summary>
        /// 获取一级菜单树
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Module> GetFirstMenu()
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                return dbcontext.Modules.Where(t => t.ParentID == 0).ToList();
            }
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(Module entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Modules.Add(entity);
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Modify(Module entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Entry<Module>(entity).State = System.Data.Entity.EntityState.Modified;
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Remove(Module entity)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                dbcontext.Modules.Attach(entity);
                dbcontext.Modules.Remove(entity);
                return dbcontext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 分页查询(获取菜单分页)
        /// </summary>
        /// <param name="pageNumber">当前页</param>
        /// <param name="pageSize">单页显示数量</param>
        /// <param name="sortOrder">排序条件</param>
        /// <param name="parentNo">父级编号</param>
        /// <param name="Number">总记录数</param>
        /// <returns></returns>
        public IEnumerable<Module> GetAdminMenusForPaging(int pageNumber, int pageSize,  int parentNo, out int Number)
        {
            using (ManagementDBContext dbcontext = new ManagementDBContext())
            {
                var result = from module in dbcontext.Modules
                             where module.ParentID == parentNo
                             select module;
                Number = result.Count();
                return result.Distinct().OrderBy(p=>p.MID).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }

        }
    }
}
