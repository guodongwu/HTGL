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
    public interface ISysUserService:IDependency
    {

        IQueryable<SysUser> SysUsers { get; }


        OperationResult Add(SysUser sysUser);
        OperationResult Remove(SysUser sysUser);
        OperationResult Save(SysUser sysUser);

        SysUser FindBy(Func<SysUser, bool> where);

        List<SysUser> FindAll();
        List<SysUser> FindAll(Func<SysUser, bool> where);

        List<SysUser> FindAll<Tkey>(Func<SysUser, bool> where, Func<SysUser, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total);


        SysUser Login(string UserName, string Password);
        bool ChangePassword(SysUserVM request, int userId);
    }
}

