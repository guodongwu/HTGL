using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using HTGL.Service;
using HTGL.Service.Interface;
using HTGL.Data.Repositories;

namespace HTGL.Service.Implement
{
    public class SysUserRoleService : BaseService, ISysUserRoleService
    {

        public ISysUserRoleRepository _sysUserRoleRepository;
        public ISysRoleMenuRepository _sysRoleMenuRepository;
        public ISysMenuRepository _sysMenuRepository;
        public SysUserRoleService(ISysUserRoleRepository sysUserRoleRepository,
            ISysRoleMenuRepository sysRoleMenuRepository, ISysMenuRepository sysMenuRepository,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _sysUserRoleRepository = sysUserRoleRepository;
            _sysRoleMenuRepository = sysRoleMenuRepository;
            _sysMenuRepository = sysMenuRepository;
        }
        public IQueryable<SysUserRole> SysUserRoles
        {
            get { return _sysUserRoleRepository.Entities; }
        }

        public IQueryable<SysMenu> SysMenus
        {
            get { return _sysMenuRepository.Entities; }

        }

        public OperationResult Add(SysUserRole sysUserRole)
        {
            try
            {
                var entity = SysUserRoles.FirstOrDefault(c => c.UserId == sysUserRole.UserId && c.RoleId == sysUserRole.RoleId);
                if (entity != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的模块，请修改后重新提交！");
                }
                entity = new SysUserRole
                {
                    UserId = sysUserRole.UserId,
                    RoleId = sysUserRole.RoleId,
                    AddTime = sysUserRole.AddTime,
                    AddIP = sysUserRole.AddIP,
                    AddUserId = sysUserRole.AddUserId,
                    Description = sysUserRole.Description,
                    Status = sysUserRole.Status
                };
                _sysUserRoleRepository.Insert(entity);
                return new OperationResult(OperationResultType.Success, "新增数据成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增数据失败，数据库插入数据时发生了错误!");
            }
        }

        public OperationResult Remove(SysUserRole sysUserRole)
        {
            try
            {
                _sysUserRoleRepository.Delete(sysUserRole);
                return new OperationResult(OperationResultType.Success, "删除数据成功！");
            }
            catch (Exception)
            {
                
               return new OperationResult(OperationResultType.Error, "删除数据失败！");
            }
        }

        public OperationResult Save(SysUserRole sysUserRole)
        {
            try
            {
                _sysUserRoleRepository.Update(sysUserRole);
                return new OperationResult(OperationResultType.Success, "修改数据成功！");
            }
            catch (Exception)
            {
                
                 return new OperationResult(OperationResultType.Error, "修改数据失败！");
            }
        }

        public SysUserRole FindBy(Func<SysUserRole, bool> where)
        {
            return SysUserRoles.FirstOrDefault(where);
        }

        public List<SysUserRole> FindAll()
        {
            return SysUserRoles.ToList();
        }

        public List<SysUserRole> FindAll(Func<SysUserRole, bool> where)
        {
            return SysUserRoles.Where(where).ToList();
        }

        public List<SysUserRole> FindAll<Tkey>(Func<SysUserRole, bool> where, Func<SysUserRole, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            total = SysUserRoles.Where(where).Count();
            return SysUserRoles.Where(where).OrderByDescending(orderbyLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        /// <summary>
        /// 获取所有的Roles
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserAllRole(int UserID)
        {

            var roles = SysUserRoles.Where(t => t.UserId == UserID).ToList();
            var rolesStr = "";
            foreach (var item in roles)
            {
                if (!String.IsNullOrEmpty(rolesStr))
                    rolesStr += ",";
                rolesStr += item.RoleId;
            }
            return rolesStr;
        }

        public IEnumerable<SysMenuVM> GetUserPermissionMenus(int roleId, int userId)
        {
            var roleUser = FindBy(p => p.RoleId == roleId && p.UserId == userId);
            if (roleUser != null)
            {
                var roleMenu = _sysRoleMenuRepository.Entities.Where(p =>p.Status && p.RoleId == roleId).ToList();
                if (roleMenu.Count > 0)
                {
                    var arr = roleMenu.Select(p =>p.MenuId).ToArray();
                    var menus= SysMenus.Where(p=>p.IsVisible &&p.IsMenu && arr.Contains(p.MenuId)).ToList();

                    List<SysMenuVM> menusList = new List<SysMenuVM>();
                    //获取当前角色的json菜单数据
                   // IEnumerable<Sys> RolesMenus = GetRoleMenu(roles, adminRoleId);
                    //首先找出父级菜单
                    var ParentMenus = menus.Where(p => p.ParentMenuId == 0);
                    foreach (SysMenu item in ParentMenus)
                    {
                        SysMenuVM roleMenuParent = SysMenuVM.ToViewModel(item);
                        //添加子菜单
                        foreach (SysMenu childMenu in menus)
                        {
                            SysMenuVM childViewMenu = SysMenuVM.ToViewModel(childMenu);
                            if (childViewMenu.ParentID == roleMenuParent.ID)
                            {
                                if (roleMenuParent.children == null)
                                    roleMenuParent.children = new List<SysMenuVM>();
                                roleMenuParent.children.Add(childViewMenu);
                            }
                        }
                        menusList.Add(roleMenuParent);
                    }
                    return menusList;
                }
            }

            return null;

        }
    }
}

