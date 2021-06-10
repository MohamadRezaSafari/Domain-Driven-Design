using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeCreateCommandHandler : ICommandHandler<EmployeeCreateCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeCreateCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void Execute(EmployeeCreateCommand command)
        {
            Employee employee = new Employee(command.FirstName, command.LastName);
            _employeeRepository.Create(employee);
        }
    }
}
