using Framework.Core.Domain;
using Framework.Core.Persistence;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Persistence
{
    public abstract class RepositoryBase<TAggregateRoot>:IRepository where TAggregateRoot : EntityBase, IAggregateRoot
    {
        protected readonly DbContextBase dbContext;

        protected RepositoryBase(IDbContext dbContext)
        {
            this.dbContext = (DbContextBase)dbContext;
        }

        protected void Create(TAggregateRoot aggregateRoot)
        {
            dbContext.Set<TAggregateRoot>().Add(aggregateRoot);
        }

        protected void Update(TAggregateRoot aggregateRoot)
        {
            dbContext.Set<TAggregateRoot>();
        }

        protected void Remove(TAggregateRoot aggregateRoot)
        {
            dbContext.Set<TAggregateRoot>().Remove(aggregateRoot);
        }

        protected abstract IEnumerable<Expression<Func<TAggregateRoot, object>>> GetAggregateExpression();
        protected IQueryable<TAggregateRoot> Set
        {
            get
            {
                var set = this.dbContext.Set<TAggregateRoot>().AsQueryable();
                var includeExpression = GetAggregateExpression();
                if (includeExpression != null)
                {
                    foreach (var expression in includeExpression)
                    {
                        set = set.Include(expression);
                    }
                }

                return set;
            }

        }

        protected TAggregateRoot GetById(Guid id)
        {
            return Set.Single(e => e.Id == id);
        }
    }
}
