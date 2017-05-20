using Management.Dao;
using Management.Entity;
using Management.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.BLL
{
    public class ModuleService
    {
        ModuleDao dao = null;
        public ModuleService()
        {
            dao = new ModuleDao();
        }

        /// <summary>
        /// 获取一级菜单树
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ViewModelMenu> GetFirstMenu()
        {
            List<ViewModelMenu> menuList = new List<ViewModelMenu>();
            var list = dao.GetFirstMenu();
            foreach (var item in list)
            {
                ViewModelMenu entity = ViewModelMenu.ToViewModel(item);
                menuList.Add(entity);
            }
            return menuList;
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(Module entity)
        {
            return dao.Insert(entity);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Module entity)
        {
            return dao.Modify(entity);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(Module entity)
        {
            return dao.Remove(entity);
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <param name="request">请求条件</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public IEnumerable<Module> GetAdminMenus(UIGridRequest request, int parentNo, out int count)
        {
            return dao.GetAdminMenusForPaging(request.PageNumber, request.PageSize, parentNo, out count);
        }
    }
}
