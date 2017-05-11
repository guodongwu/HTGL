using System;
using System.Collections.Generic;
using System.Linq;
using HTGL.Component.Tools;
using HTGL.Data.Repositories;
using HTGL.Model;
using HTGL.Repository.EF;
using HTGL.Service.Interface;

namespace HTGL.Service.Implement
{
    public class SysMenuService : BaseService, ISysMenuService
    {


        private readonly ISysMenuRepository _sysMenuRepository;
        public SysMenuService(ISysMenuRepository sysMenuRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _sysMenuRepository = sysMenuRepository;
        }
        public IQueryable<SysMenu> SysMenus
        {
            get
            {
                return _sysMenuRepository.Entities;
            }
        }
        public OperationResult Add(SysMenu sysMenu)
        {
            _sysMenuRepository.Insert(sysMenu);
            return new OperationResult(OperationResultType.Success);
        }

        public OperationResult Remove(SysMenu sysMenu)
        {
            sysMenu.IsVisible = false;
            _sysMenuRepository.Update(sysMenu);
            return new OperationResult(OperationResultType.Success);
        }

        public OperationResult Save(SysMenu sysMenu)
        {
            _sysMenuRepository.Update(sysMenu);
            return new OperationResult(OperationResultType.Success);

        }

        public SysMenu FindBy(Func<SysMenu, bool> @where)
        {
            throw new NotImplementedException();
        }

        public List<SysMenu> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<SysMenu> FindAll(Func<SysMenu, bool> @where)
        {
            throw new NotImplementedException();
        }

        public List<SysMenu> FindAll<Tkey>(Func<SysMenu, bool> @where, Func<SysMenu, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取一级菜单树
        /// </summary>
        /// <returns></returns>
        public List<SysMenuVM> GetFirstMenu()
        {
            List<SysMenuVM> menuList = new List<SysMenuVM>();
            var list = SysMenus.Where(p => p.ParentMenuId == 0).ToList();
            foreach (var item in list)
            {
                SysMenuVM entity = SysMenuVM.ToViewModel(item);
                menuList.Add(entity);
            }
            return menuList;
        }

        public IEnumerable<SysMenuVM> GetUserTreeMenus(UITreeRequest request, int currentRole)
        {
            //返回ui层的菜单
            IEnumerable<SysMenuVM> rootMenus = new List<SysMenuVM>(){
            new SysMenuVM()
            {
                Icon = request.RootIcon,
                ParentID = request.PidField,
                ID = !string.IsNullOrEmpty(request.IdField)?int.Parse(request.IdField):0,
                Text = "主菜单",
                children = GetFirstMenu()
            }};
            return rootMenus;
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <param name="request">请求条件</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public IEnumerable<SysMenu> GetAdminMenus(UIGridRequest request, int parentNo, out int count)
        {
            var menus = SysMenus.Where(p => p.ParentMenuId == parentNo).Distinct();
            count = menus.Count();
            int pageNumber = request.PageNumber;
            int pageSize = request.PageSize;
            return menus.OrderByDescending(p => p.MenuId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        public UIGrid GetUserGridMenus(UIGridRequest request, int userRoles, int parentNo)
        {
            int total = 0;
            UIGrid grid = new UIGrid();
            grid.Rows = GetAdminMenus(request, parentNo, out total);
            //记录总数
            grid.Total = total;
            //返回ui层的菜单
            return grid;
        }
    }
}