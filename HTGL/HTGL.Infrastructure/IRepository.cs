using HTGL.Component.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HTGL.Infrastructure
{
    public interface IRepository<TEntity, in TKey> where TEntity : EntityBase<TKey>
    {
        #region 单体查询
        TEntity Find(object id);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(Expression<Func<TEntity, bool>> predicate,string[] includeProperties);
        #endregion

        #region 列表查询
        IQueryable<TEntity> FindList();
        IQueryable<TEntity> FindList(Expression<Func<TEntity, bool>> predicate);
        //IQueryable<TEntity> FindList(Expression<Func<TEntity, bool>> predicate,int number);

        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool isAsc);
        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool isAsc, int number);
        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, TOrder>> order, bool isAsc, int number,string[] includeProperties);
        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc);
        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc, int number);
        //IQueryable<TEntity> FindList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc, int number,string[] includeProperties);

        IQueryable<TEntity> FindPageList(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex, out int totalCount);
        IQueryable<TEntity> FindPageList(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex, out int totalCount, string[] includeProperties);

        IQueryable<TEntity> FindPageList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc, int pageSize,int pageIndex,out int totalCount);
        IQueryable<TEntity> FindPageList<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, bool isAsc, int pageSize, int pageIndex, out int totalCount, string[] includeProperties);
        #endregion

        #region 新增
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        #endregion

        #region 删除
        void Delete(object id);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region 编辑
        void Edit(TEntity entity);
        void Edit(TEntity entity, string[] changedProperties);
        #endregion
    }
}
