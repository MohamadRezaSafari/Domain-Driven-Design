using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using System;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void Create(Employee employee)
        {
            base.Create(employee);
        }
    }
}
