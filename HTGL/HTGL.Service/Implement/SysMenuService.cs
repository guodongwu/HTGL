using System;
using System.Collections.Generic;
using System.Linq;
using HTGL.Component.Tools;
using HTGL.Data.Repositories;
using HTGL.Model;
using HTGL.Repository.EF;
using HTGL.Service.Interface;

namespace HTGL.Service.Implement
{
    public class SysMenuService : BaseService, ISysMenuService
    {


           private readonly ISysMenuRepository _sysMenuRepository;
           public SysMenuService(ISysMenuRepository sysMenuRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _sysMenuRepository = sysMenuRepository;
        }
           public IQueryable<SysMenu> SysMenus
           {
               get
               {
                   return _sysMenuRepository.Entities;
               }
           }
        public OperationResult Add(SysMenu sysMenu)
        {
            throw new NotImplementedException();
        }

        public OperationResult Remove(SysMenu sysMenu)
        {
            throw new NotImplementedException();
        }

        public OperationResult Save(SysMenu sysMenu)
        {
            throw new NotImplementedException();
        }

        public SysMenu FindBy(Func<SysMenu, bool> @where)
        {
            throw new NotImplementedException();
        }

        public List<SysMenu> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<SysMenu> FindAll(Func<SysMenu, bool> @where)
        {
            throw new NotImplementedException();
        }

        public List<SysMenu> FindAll<Tkey>(Func<SysMenu, bool> @where, Func<SysMenu, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            throw new NotImplementedException();
        }
    }
}