using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTGL.Repository.EF;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace HTGL.Repository.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {

        /// <summary>
        /// 获取或设置 当前使用的数据访问上下文对象
        /// </summary>
        protected DbContext Context
        {
            get
            {
                return DataContextFactory.GetCurrentDbContext();
            }
        }
        protected bool _isDisposed;
        public EFUnitOfWork()
        {
            _isDisposed = false;
        }
        public int Commit()
        {
            try
            {
                int result = Context.SaveChanges();
                return result;
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException != null && e.InnerException.InnerException is SqlException)
                {
                    SqlException sqlEx = e.InnerException.InnerException as SqlException;
                    //string msg = DataHelper.GetSqlExceptionMessage(sqlEx.Number);
                    //throw PublicHelper.ThrowDataAccessException("提交数据更新时发生异常：" + msg, sqlEx);
                }
                throw;
            }
        }

        #region Dispose方法
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _isDisposed = true;
        }
        #endregion
    }
}
