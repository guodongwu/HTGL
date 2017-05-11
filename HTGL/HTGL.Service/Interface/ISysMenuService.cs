using System;
using System.Collections.Generic;
using System.Linq;
using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Repository.EF;

namespace HTGL.Service.Interface
{
    public interface ISysMenuService : IDependency
    {
        IQueryable<SysMenu> SysMenus { get; }


        OperationResult Add(SysMenu sysMenu);
        OperationResult Remove(SysMenu sysMenu);
        OperationResult Save(SysMenu sysMenu);

        SysMenu FindBy(Func<SysMenu, bool> where);

        List<SysMenu> FindAll();
        List<SysMenu> FindAll(Func<SysMenu, bool> where);

        List<SysMenu> FindAll<Tkey>(Func<SysMenu, bool> where, Func<SysMenu, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total);

        IEnumerable<SysMenuVM> GetUserTreeMenus(UITreeRequest request,int currentRole);
        UIGrid GetUserGridMenus(UIGridRequest request, int userRoles, int parentNo);
    }
}