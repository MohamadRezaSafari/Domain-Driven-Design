using Framework.Persistence;
using HR.EmployeeContext.Domain.EmployeeIos;
using HR.EmployeeContext.Domain.EmployeeIos.Services;

namespace HR.EmployeeContext.Infrastructure.Persistence.EmployeeIos
{
    public class EmployeeIORepository : RepositoryBase<EmployeeIo>, IEmployeeIORepository
    {
        public EmployeeIORepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void Create(EmployeeIo employemIo)
        {
            base.Create(employemIo);
        }
    }
}
