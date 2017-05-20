using Management.Dao;
using Management.Entity;
using Management.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.BLL
{
    public class ModulePermissionService
    {
        ModulePermissionDao dao = null;
        public ModulePermissionService()
        {
            dao = new ModulePermissionDao();
        }

        /// <summary>
        /// 获取菜单的按钮信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UIGrid GetMenuButtons(UIGridRequest request, string controllName)
        {
            int count = 0;
            var data = dao.GetModulePermissionForPaging(request.PageNumber, request.PageSize, controllName, out count);
            return new UIGrid()
            {
                Rows = data,
                Total = count
            };
        }

        /// <summary>
        /// 获取所有权限信息
        /// </summary>
        /// <returns></returns>
        public UIGrid GetAllPermission()
        {
            var data = dao.GetAllPermission();
            return new UIGrid() { Rows = data, Total = data.Count() };
        }

        /// <summary>
        /// 添加菜单按钮信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(ModulePermission entity)
        {
            return dao.Insert(entity);
        }

        /// <summary>
        /// 修改菜单按钮信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(ModulePermission entity)
        {
            return dao.Modify(entity);
        }

        /// <summary>
        /// 删除菜单按钮信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(ModulePermission entity)
        {
            return dao.Remove(entity);
        }
    }
}
