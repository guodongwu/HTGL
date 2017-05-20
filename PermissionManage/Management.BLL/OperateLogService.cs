using Management.Dao;
using Management.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Management.ViewModel;

namespace Management.BLL
{
    public class OperateLogService
    {
        OperateLogDao dao = null;
        public OperateLogService()
        {
            dao = new OperateLogDao();
        }
        /// <summary>
        /// 根据月份数删除日志
        /// </summary>
        /// <param name="month">删除的月份数量</param>
        /// <returns></returns>
        public bool DeleteOperateLogByMonth(int month)
        {
            return dao.DeleteOperateLogByMonth(month);
        }

        /// <summary>
        /// 删除全部日志
        /// </summary>
        /// <returns></returns>
        public bool DeleteOperateLogAll()
        {
            return dao.DeleteOperateLogAll();
        }

        /// <summary>
        /// 删除单个日志
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteOperateLogEntity(OperateLog entity)
        {
            return dao.DeleteOperateLogEntity(entity);
        }

        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertOperateLog(OperateLog entity)
        {
            return dao.InsertOperateLog(entity);
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <param name="request">请求条件</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public UIGrid GetALLOperateLogs(UIGridRequest request, string userName, string ipAddress, string startDate, string endDate)
        {
            int count = 0;
            DateTime? startDt = null; DateTime? endDt = null; DateTime tryDt = DateTime.Now;
            if (!String.IsNullOrEmpty(startDate) && DateTime.TryParse(startDate, out tryDt))
                startDt = tryDt;
            if (!String.IsNullOrEmpty(endDate) && DateTime.TryParse(endDate, out tryDt))
                endDt = tryDt;
            var data = dao.GetOperateLogsForPaging(userName, ipAddress, startDt, endDt, request.PageNumber, request.PageSize, out count);
            return new UIGrid() { Rows = data, Total = count };
        }

        /// <summary>
        /// 根据ID获取日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperateLog GetOperateLogByID(string id)
        {
            int oid = 0;
            int.TryParse(id, out oid);
            return dao.GetOperateLogByID(oid);
        }
    }
}
