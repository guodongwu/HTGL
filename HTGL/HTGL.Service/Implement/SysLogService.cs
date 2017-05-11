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
    public class SysLogService : BaseService, ISysLogService
    {
        private readonly ISysLogRepository _sysLogRepository;
        public SysLogService(ISysLogRepository sysLogRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _sysLogRepository = sysLogRepository;
        }


        public IQueryable<SysLog> SysLogs
        {
            get
            {
                return _sysLogRepository.Entities;

            }
        }
        public OperationResult Add(SysLog sysLog)
        {
            try
            {
                _sysLogRepository.Insert(sysLog);
                return new OperationResult(OperationResultType.Success, "新增数据成功！");
            }
            catch (Exception)
            {

                return new OperationResult(OperationResultType.Error, "新增数据失败，数据库插入数据时发生了错误!");
            }
        }

        public OperationResult Remove(SysLog sysLog)
        {
            throw new NotImplementedException();
        }

        public OperationResult Save(SysLog sysLog)
        {
            throw new NotImplementedException();
        }

        public SysLog FindBy(Func<SysLog, bool> @where)
        {
            throw new NotImplementedException();
        }

        public List<SysLog> FindAll()
        {
            return SysLogs.ToList();
        }

        public List<SysLog> FindAll(Func<SysLog, bool> @where)
        {
            throw new NotImplementedException();
        }

        public List<SysLog> FindAll<Tkey>(Func<SysLog, bool> @where, Func<SysLog, Tkey> orderbyLambda, int pageIndex, int pageSize, bool isAsc, out int total)
        {
            throw new NotImplementedException();
        }

        public UIGrid GetAllOperateLogs(UIGridRequest request, string username, string ipaddress, string startdt, string enddt)
        {
            int count = 0;
            DateTime? startDt = null; DateTime? endDt = null; DateTime tryDt = DateTime.Now;
            if (!String.IsNullOrEmpty(startdt) && DateTime.TryParse(startdt, out tryDt))
                startDt = tryDt;
            if (!String.IsNullOrEmpty(enddt) && DateTime.TryParse(enddt, out tryDt))
                endDt = tryDt;
            var data = FindAll();
            if (!string.IsNullOrEmpty(username))
                data.Where(p => p.UserName == username);
            if (startDt != null)
                data = data.Where(p => p.OperatingTime.Date>= startDt.Value.Date).ToList();
            if (endDt != null)
                data = data.Where(p => p.OperatingTime.Date <= endDt.Value.Date).ToList();
            if (!string.IsNullOrEmpty(ipaddress))
                data = data.Where(p => p.OperatingIp == ipaddress).ToList();
            count = data.Count();
            int pageNumber = request.PageNumber;
            int pageSize = request.PageSize;
            data= data.Distinct().OrderByDescending(p => p.LogId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new UIGrid() { Rows = data, Total = count };
        }
    }
}