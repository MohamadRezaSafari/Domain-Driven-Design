
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Services.Employees
{
    public class EmployeeIsExists: IEmployeeIsExists
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeIsExists(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool IsExists(long EmployeeId)
        {
            return _employeeRepository.Any(e => e.EmployeeId == EmployeeId && e.IsActive);
        }
    }
}