using System;
using System.Collections.Generic;
using System.Linq;
using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Repository.EF;

namespace HTGL.Service.Interface
{
    public interface ISysRoleMenuService : IDependency
    {
        IQueryable<SysRoleMenu> SysRoleMenus { get; }


        OperationResult Add(SysRoleMenu sysRoleMenu);
        OperationResult Remove(SysRoleMenu sysRoleMenu);
        OperationResult Save(SysRoleMenu sysRoleMenu);

        SysRoleMenu FindBy(Func<SysRoleMenu, bool> where);

        List<SysRoleMenu> FindAll();
        List<SysRoleMenu> FindAll(Func<SysRoleMenu, bool> where);

        List<SysRoleMenu> FindAll<Tkey>(Func<SysRoleMenu, bool> where, Func<SysRoleMenu, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total);
    }
}