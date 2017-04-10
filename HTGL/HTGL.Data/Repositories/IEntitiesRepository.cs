using HTGL.Model;
using HTGL.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HTGL.Data.Repositories
{
    public interface ISysDbBackupRepository : IRepository<SysDbBackup, Int32>, IDependency
    {

    }
    public interface ISysDictRepository : IRepository<SysDict, Int32>, IDependency
    {

    }
    public interface ISysFunctionRepository : IRepository<SysFunction, Int32>, IDependency
    {

    }
    public interface ISysLogRepository : IRepository<SysLog, Int32>, IDependency
    {

    }
    public interface ISysMenuRepository : IRepository<SysMenu, Int32>, IDependency
    {

    }
    public interface ISysMenuFunctionRepository : IRepository<SysMenuFunction, Int32>, IDependency
    {

    }
    public interface ISysOrganizeRepository : IRepository<SysOrganize, Int32>, IDependency
    {

    }
    public interface ISysRoleRepository : IRepository<SysRole, Int32>, IDependency
    {

    }
    public interface ISysRoleMenuRepository : IRepository<SysRoleMenu, Int32>, IDependency
    {

    }
    public interface ISysUserRepository : IRepository<SysUser, Int32>, IDependency
    {

    }
    public interface ISysUserRoleRepository : IRepository<SysUserRole, Int32>, IDependency
    {

    }

}

