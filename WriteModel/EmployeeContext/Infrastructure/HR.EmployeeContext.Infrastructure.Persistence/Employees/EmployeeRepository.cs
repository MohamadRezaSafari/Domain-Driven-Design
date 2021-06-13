using System;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using System.Linq;
using System.Linq.Expressions;

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
        
        public void Update(Employee employee)
        {
            base.Update(employee);
        }

        public Employee GetByEmployeeId(long employeeId)
        {
            return dbContext.Set<Employee>().SingleOrDefault(e => e.EmployeeId == employeeId);
        }

        public bool Any(Expression<Func<Employee, bool>> expression)
        {
            return dbContext.Set<Employee>().Any(expression);
        }
    }
}
