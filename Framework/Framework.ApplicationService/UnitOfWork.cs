using Framework.Core.ApplicationService;
using Framework.Persistence;

namespace Framework.ApplicationService
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }
    }
}