
using App.Shared.Models;

namespace App.Shared.Infrastructure
{
    public class IBaseRepo<TEntity, TContext> : IBaseInterface<TEntity, TContext> 
        where TEntity : class,IAggregateRoot 
        where TContext : BaseContext<TContext>,IAggregateRoot
    {
        protected readonly BaseContext<TContext> Context;



        public IBaseRepo(BaseContext<TContext>  context)
        {
            Context = context;

            if (context != null)
            {
                //_dbSet = context.Set<TEntity>;
            }
        }


        public virtual void Add(TEntity entity)
        {

            Context.Set<TEntity>().Add(entity);
        }


        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }


        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await Context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> include)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>().Include(include);

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate).ConfigureAwait(false);
        }


        public virtual async Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams)
        {
            return await GetOrderedPageQueryResultAsync(queryObjectParams, Context.Set<TEntity>()).ConfigureAwait(false);
        }


        public virtual async Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            return await GetOrderedPageQueryResultAsync(queryObjectParams, query).ConfigureAwait(false);
        }

        public virtual async Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, List<Expression<Func<TEntity, object>>> includes)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await GetOrderedPageQueryResultAsync(queryObjectParams, query).ConfigureAwait(false);
        }



        public virtual async Task<QueryResult<TEntity>> GetPageAsync<TProperty>(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate, List<Expression<Func<TEntity, TProperty>>> includes = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await GetOrderedPageQueryResultAsync(queryObjectParams, query).ConfigureAwait(false);
        }



        public virtual async Task<QueryResult<TEntity>> GetOrderedPageQueryResultAsync(QueryObjectParams queryObjectParams, IQueryable<TEntity> query)
        {
            IQueryable<TEntity> OrderedQuery = query;

            if (queryObjectParams.SortingParams != null && queryObjectParams.SortingParams.Count > 0)
            {
                OrderedQuery = SortingExtension.GetOrdering(query, queryObjectParams.SortingParams);
            }

            var totalCount = await query.CountAsync().ConfigureAwait(false);

            if (OrderedQuery != null)
            {
                var fecthedItems = await GetPagePrivateQuery(OrderedQuery, queryObjectParams).ToListAsync().ConfigureAwait(false);

                return new QueryResult<TEntity>(fecthedItems, totalCount);
            }

            return new QueryResult<TEntity>(await GetPagePrivateQuery(Context.Set<TEntity>(), queryObjectParams).ToListAsync().ConfigureAwait(false), totalCount);
        }


        private IQueryable<TEntity> GetPagePrivateQuery(IQueryable<TEntity> query, QueryObjectParams queryObjectParams)
        {
            return query.Skip((queryObjectParams.PageNumber - 1) * queryObjectParams.PageSize).Take(queryObjectParams.PageSize);
        }

    }
}