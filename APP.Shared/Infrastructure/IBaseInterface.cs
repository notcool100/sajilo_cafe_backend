﻿using System.Linq.Expressions;

namespace App.Shared.Infrastructure
{
    public interface IBaseInterface<TEntity,TContext> 
        where TEntity : IAggregateRoot
        where TContext : BaseContext<TContext>, IAggregateRoot

    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);


        Task<TEntity> GetByIdAsync(object id);


        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> include);


        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);


        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams);


        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate);

        Task<QueryResult<TEntity>> GetOrderedPageQueryResultAsync(QueryObjectParams queryObjectParams, IQueryable<TEntity> query);
        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, List<Expression<Func<TEntity, object>>> includes);
        Task<QueryResult<TEntity>> GetPageAsync<TProperty>(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate, List<Expression<Func<TEntity, TProperty>>> includes = null);
    }
    public interface IAggregateRoot
    {

    }
}