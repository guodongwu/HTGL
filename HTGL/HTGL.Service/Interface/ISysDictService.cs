using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HTGL.Service.Interface
{
    public interface ISysDictService : IDependency
    {

        IQueryable<SysDict> SysDicts { get; }


        OperationResult Add(SysDict sysDict);
        OperationResult Remove(SysDict sysDict);
        OperationResult Save(SysDict sysDict);

        SysDict FindBy(Func<SysDict, bool> where);

        List<SysDict> FindAll();
        List<SysDict> FindAll(Func<SysDict, bool> where);

        List<SysDict> FindAll<Tkey>(Func<SysDict, bool> where, Func<SysDict, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total);

    }
}

