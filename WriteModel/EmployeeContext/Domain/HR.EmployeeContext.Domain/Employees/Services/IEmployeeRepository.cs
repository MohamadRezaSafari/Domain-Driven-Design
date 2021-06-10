using Framework.Core.Persistence;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface IEmployeeRepository : IRepository
    {
        void Create(Employee employee);
    }
}
