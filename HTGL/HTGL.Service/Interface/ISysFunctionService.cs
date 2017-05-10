using System;
using System.Collections.Generic;
using System.Linq;
using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Repository.EF;

namespace HTGL.Service.Interface
{
    public interface ISysFunctionService : IDependency
    {
        IQueryable<SysFunction> SysFunctions { get; }


        OperationResult Add(SysFunction sysFunction);
        OperationResult Remove(SysFunction sysFunction);
        OperationResult Save(SysFunction sysFunction);

        SysDbBackup FindBy(Func<SysFunction, bool> where);

        List<SysFunction> FindAll();
        List<SysFunction> FindAll(Func<SysFunction, bool> where);

        List<SysFunction> FindAll<Tkey>(Func<SysFunction, bool> where, Func<SysFunction, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total);

        List<SysFunction> GetButtons(string menuNo);

    }
}