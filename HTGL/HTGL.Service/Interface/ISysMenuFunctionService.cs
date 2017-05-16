using System;
using System.Collections.Generic;
using System.Linq;
using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Repository.EF;

namespace HTGL.Service.Interface
{
    public interface ISysMenuFunctionService : IDependency
    {
        IQueryable<SysMenuFunction> SysMenuFunctions { get; }


        OperationResult Add(SysMenuFunction sysMenuFunction);
        OperationResult Remove(SysMenuFunction sysMenuFunction);
        OperationResult Save(SysMenuFunction sysMenuFunction);

        SysMenuFunction FindBy(Func<SysMenuFunction, bool> where);

        List<SysMenuFunction> FindAll();
        List<SysMenuFunction> FindAll(Func<SysMenuFunction, bool> where);

        List<SysMenuFunction> FindAll<Tkey>(Func<SysMenuFunction, bool> where, Func<SysMenuFunction, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total);

        UIGrid GetMenuButtons(UIGridRequest request, string MenuController);
    }
}