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
    public interface ISysDbBackupService : IDependency
    {

        IQueryable<SysDbBackup> SysDbBackups { get; }


        OperationResult Add(SysDbBackup sysDbBackup);
        OperationResult Remove(SysDbBackup sysDbBackup);
        OperationResult Save(SysDbBackup sysDbBackup);

        SysDbBackup FindBy(Func<SysDbBackup, bool> where);

        List<SysDbBackup> FindAll();
        List<SysDbBackup> FindAll(Func<SysDbBackup, bool> where);

        List<SysDbBackup> FindAll<Tkey>(Func<SysDbBackup, bool> where, Func<SysDbBackup, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total);

    }
}

