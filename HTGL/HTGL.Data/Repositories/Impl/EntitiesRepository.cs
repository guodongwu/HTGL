using HTGL.Model;
using HTGL.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HTGL.Data.Repositories.Impl
{
    public class SysDbBackupRepository : BaseRepository<SysDbBackup, Int32>, ISysDbBackupRepository
    {
        public SysDbBackupRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
    public class SysDictRepository : BaseRepository<SysDict, Int32>, ISysDictRepository
    {
        public SysDictRepository(IUnitOfWork unitOfWork)
            : base()
        { }

    }
    public class SysFunctionRepository : BaseRepository<SysFunction, Int32>, ISysFunctionRepository
    {
        public SysFunctionRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
    public class SysLogRepository : BaseRepository<SysLog, Int32>, ISysLogRepository
    {
        public SysLogRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
    public class SysMenuRepository : BaseRepository<SysMenu, Int32>, ISysMenuRepository
    {
        public SysMenuRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
    public class SysMenuFunctionRepository : BaseRepository<SysMenuFunction, Int32>, ISysMenuFunctionRepository
    {
        public SysMenuFunctionRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
    public class SysOrganizeRepository : BaseRepository<SysOrganize, Int32>, ISysOrganizeRepository
    {
        public SysOrganizeRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
    public class SysRoleRepository : BaseRepository<SysRole, Int32>, ISysRoleRepository
    {
        public SysRoleRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
    public class SysRoleMenuRepository : BaseRepository<SysRoleMenu, Int32>, ISysRoleMenuRepository
    {
        public SysRoleMenuRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
    public class SysUserRepository : BaseRepository<SysUser, Int32>, ISysUserRepository
    {
        public SysUserRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
    public class SysUserRoleRepository : BaseRepository<SysUserRole, Int32>, ISysUserRoleRepository
    {
        public SysUserRoleRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
}

