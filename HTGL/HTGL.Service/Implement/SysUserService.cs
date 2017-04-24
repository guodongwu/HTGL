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
    public class SysUserService : BaseService, ISysUserService
    {

        private readonly ISysUserRepository _sysUserRepository;
        public SysUserService(ISysUserRepository sysUserRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _sysUserRepository = sysUserRepository;
        }

        public IQueryable<SysUser> SysUsers
        {
            get
            {
                return _sysUserRepository.Entities;

            }
        }

        public OperationResult Add(SysUser sysUser)
        {
            try
            {
                var entity = SysUsers.FirstOrDefault(c => c.Phone == sysUser.Phone.Trim());
                if (entity != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的模块，请修改后重新提交！");
                }
                entity = new SysUser
                {
                    UserName = sysUser.UserName,
                    Password = sysUser.Password,
                    Phone = sysUser.Phone

                };
                _sysUserRepository.Insert(entity);
                return new OperationResult(OperationResultType.Success, "新增数据成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增数据失败，数据库插入数据时发生了错误!");
            }
        }

        public OperationResult Remove(SysUser sysUser)
        {
            _sysUserRepository.Delete(sysUser);
            return new OperationResult(OperationResultType.Success, "删除数据成功！");
        }

        public OperationResult Save(SysUser sysUser)
        {
            _sysUserRepository.Update(sysUser);
            return new OperationResult(OperationResultType.Success, "修改数据成功！");
        }

        public SysUser FindBy(Func<SysUser, bool> where)
        {
            return SysUsers.FirstOrDefault(where);
        }

        public List<SysUser> FindAll()
        {
            return SysUsers.ToList();
        }

        public List<SysUser> FindAll(Func<SysUser, bool> where)
        {
            return SysUsers.Where(where).ToList();
        }

        public List<SysUser> FindAll<Tkey>(Func<SysUser, bool> where, Func<SysUser, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            total = SysUsers.Where(where).Count();
            return SysUsers.Where(where).OrderByDescending(orderbyLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }


        public SysUser Login(string UserName, string Password)
        {
            Password = MD5Helper.ConvertMD5(MD5Helper.ConvertMD5(Password));
            return FindBy(p => p.UserName == UserName && p.Password == Password);
        }

        public bool ChangePassword(SysUserVM request, int userId)
        {
            SysUser user = FindBy(p => p.UserId == userId);
            if (MD5Helper.ConvertMD5(user.Password) ==
                MD5Helper.ConvertMD5(request.OldPassord))
            {
                user.Password = request.NewPassword;
                _sysUserRepository.Update(user);
                return true;
            }
            else
                return false;
        }
    }
}

