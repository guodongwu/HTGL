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
    public interface ISysRoleService : IDependency
    {

        IQueryable<SysRole> SysRoles { get; }


        OperationResult Add(SysRole sysUser);
        OperationResult Remove(SysRole sysUser);
        OperationResult Save(SysRole sysUser);

        SysRole FindBy(Func<SysRole, bool> where);

        List<SysRole> FindAll();
        List<SysRole> FindAll(Func<SysRole, bool> where);

        List<SysRole> FindAll<Tkey>(Func<SysRole, bool> where, Func<SysRole, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total);

         
    }
}

