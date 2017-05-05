using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HTGL.Service;
using HTGL.Service.Interface;
using HTGL.Data.Repositories;

namespace HTGL.Service.Implement
{
    public class SysUserRoleService : BaseService, ISysUserRoleService
    {

        public ISysUserRoleRepository _sysUserRoleRepository;
        public SysUserRoleService(ISysUserRoleRepository sysUserRoleRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _sysUserRoleRepository = sysUserRoleRepository;
        }
        public IQueryable<SysUserRole> SysUserRoles
        {
            get { return _sysUserRoleRepository.Entities; }
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
            _sysUserRoleRepository.Delete(sysUserRole);
            return new OperationResult(OperationResultType.Success, "删除数据成功！");
        }

        public OperationResult Save(SysUserRole sysUserRole)
        {
            _sysUserRoleRepository.Update(sysUserRole);
            return new OperationResult(OperationResultType.Success, "修改数据成功！");
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


        public List<SysMenu> GetUserPermissionMenus(int roleId, int userId)
        {
            var userRole = _sysUserRoleRepository.Entities.Where(p => p.Status && p.UserId == userId && p.RoleId == roleId);
            return null;
        }

    }
}

