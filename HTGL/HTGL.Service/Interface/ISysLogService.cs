using System;
using System.Collections.Generic;
using System.Linq;
using HTGL.Component.Tools;
using HTGL.Model;
using HTGL.Repository.EF;

namespace HTGL.Service.Interface
{
    public interface ISysLogService : IDependency
    {
        IQueryable<SysLog> SysLogs { get; }


        OperationResult Add(SysLog sysLog);
        OperationResult Remove(SysLog sysLog);
        OperationResult Save(SysLog sysLog);

        SysLog FindBy(Func<SysLog, bool> where);

        List<SysLog> FindAll();
        List<SysLog> FindAll(Func<SysLog, bool> where);

        List<SysLog> FindAll<Tkey>(Func<SysLog, bool> where, Func<SysLog, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total);

        UIGrid GetAllOperateLogs(UIGridRequest request, string username, string ipaddress, string startdt, string enddt);
    }
}