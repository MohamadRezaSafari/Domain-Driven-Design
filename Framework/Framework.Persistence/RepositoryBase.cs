using Framework.Core.Domain;
using Framework.Core.Persistence;
using Framework.Domain;

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
    }
}
