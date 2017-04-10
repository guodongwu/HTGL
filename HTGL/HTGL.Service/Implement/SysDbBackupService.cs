using HTGL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTGL.Repository.EF;
using HTGL.Data.Repositories;
using HTGL.Component.Tools;
using HTGL.Service.Interface;

namespace HTGL.Service.Implement
{
    public class SysDbBackupService : BaseService, ISysDbBackupService
    {

        private readonly ISysDbBackupRepository _sysDbBackupRepository;
        public SysDbBackupService(ISysDbBackupRepository sysDbBackupRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _sysDbBackupRepository = sysDbBackupRepository;
        }

        public IQueryable<SysDbBackup> SysDbBackups
        {
            get
            {
                return _sysDbBackupRepository.Entities;
            }
        }

        public OperationResult Add(SysDbBackup sysDbBackup)
        {
            try
            {
                var entity = SysDbBackups.FirstOrDefault(c => c.DbName == sysDbBackup.DbName.Trim());
                if (entity != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的模块，请修改后重新提交！");
                }
                entity = new SysDbBackup
                {
                    DbName = sysDbBackup.DbName.Trim(),
                    BackupTime = DateTime.Now,
                    //UpdateDate = DateTime.Now
                };
                _sysDbBackupRepository.Insert(entity);
                return new OperationResult(OperationResultType.Success, "新增数据成功！");
            }
            catch(Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增数据失败，数据库插入数据时发生了错误!");
            }
        }

        public List<SysDbBackup> FindAll()
        {
            return SysDbBackups.ToList();
        }

        public List<SysDbBackup> FindAll(Func<SysDbBackup, bool> where)
        {
            return SysDbBackups.Where(where).ToList();
        }

        public List<SysDbBackup> FindAll<Tkey>(Func<SysDbBackup, bool> where, Func<SysDbBackup, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            total = SysDbBackups.Where(where).Count();
            return SysDbBackups.Where(where).OrderByDescending(orderbyLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public SysDbBackup FindBy(Func<SysDbBackup, bool> where)
        {
            return SysDbBackups.FirstOrDefault(where);
        }

        public OperationResult Remove(SysDbBackup sysDbBackup)
        {
            _sysDbBackupRepository.Delete(sysDbBackup);
            return new OperationResult(OperationResultType.Success, "删除数据成功！");
        }

        public OperationResult Save(SysDbBackup sysDbBackup)
        {
            _sysDbBackupRepository.Update(sysDbBackup);
            return new OperationResult(OperationResultType.Success, "修改数据成功！");
        }
    }
}
