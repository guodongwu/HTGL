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
    public class SysRoleMenuService : BaseService, ISysRoleMenuService
    {



        private readonly ISysRoleMenuRepository _sysRoleMenuRepository;
        public SysRoleMenuService(ISysRoleMenuRepository sysRoleMenuRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _sysRoleMenuRepository = sysRoleMenuRepository;
        }
        public IQueryable<SysRoleMenu> SysRoleMenus
        {
            get
            {
                return _sysRoleMenuRepository.Entities;
            }
        }




        public OperationResult Add(SysRoleMenu sysRoleMenu)
        {
            try
            {

                var entity = new SysRoleMenu
                 {
                     RoleId = sysRoleMenu.RoleId,
                     MenuId = sysRoleMenu.MenuId,
                     Status = true,
                     AddUserId = sysRoleMenu.AddUserId,
                     AddTime = DateTime.Now,
                     AddIp = ToolsHelper.GetUserIp()

                     //UpdateDate = DateTime.Now
                 };
                _sysRoleMenuRepository.Insert(entity);
                return new OperationResult(OperationResultType.Success, "新增数据成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增数据失败，数据库插入数据时发生了错误!");
            }
        }

        public OperationResult Remove(SysRoleMenu sysRoleMenu)
        {
            _sysRoleMenuRepository.Delete(sysRoleMenu);
            return new OperationResult(OperationResultType.Success, "删除数据成功！");
        }

        public OperationResult Save(SysRoleMenu sysRoleMenu)
        {
            _sysRoleMenuRepository.Update(sysRoleMenu);
            return new OperationResult(OperationResultType.Success, "修改数据成功！");
        }

        public SysRoleMenu FindBy(Func<SysRoleMenu, bool> where)
        {
            return SysRoleMenus.FirstOrDefault(where);
        }

        public List<SysRoleMenu> FindAll()
        {
            return SysRoleMenus.ToList();
        }

        public List<SysRoleMenu> FindAll(Func<SysRoleMenu, bool> where)
        {
            return SysRoleMenus.Where(where).ToList();
        }

        public List<SysRoleMenu> FindAll<Tkey>(Func<SysRoleMenu, bool> where, Func<SysRoleMenu, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            total = SysRoleMenus.Where(where).Count();
            return SysRoleMenus.Where(where).OrderByDescending(orderbyLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}