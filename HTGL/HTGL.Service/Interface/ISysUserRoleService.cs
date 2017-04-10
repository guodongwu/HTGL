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
    public interface ISysUserRoleService : IDependency
    {

        IQueryable<SysUserRole> SysUserRoles { get; }


        OperationResult Add(SysUserRole sysUserRole);
        OperationResult Remove(SysUserRole sysUserRole);
        OperationResult Save(SysUserRole sysUserRole);

        SysUserRole FindBy(Func<SysUserRole, bool> where);

        List<SysUserRole> FindAll();
        List<SysUserRole> FindAll(Func<SysUserRole, bool> where);

        List<SysUserRole> FindAll<Tkey>(Func<SysUserRole, bool> where, Func<SysUserRole, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total);

        string GetUserAllRole(int UserID);
    }
}

