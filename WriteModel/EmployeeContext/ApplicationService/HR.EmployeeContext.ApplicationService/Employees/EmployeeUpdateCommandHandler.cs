using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeUpdateCommandHandler : ICommandHandler<EmployeeUpdateCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeIsExists _employeeIsExists;

        public EmployeeUpdateCommandHandler(IEmployeeRepository employeeRepository, IEmployeeIsExists employeeIsExists)
        {
            _employeeRepository = employeeRepository;
            _employeeIsExists = employeeIsExists;
        }
        public void Execute(EmployeeUpdateCommand command)
        {
            Employee employee = _employeeRepository.GetByEmployeeId(command.EmployeeId);
            employee.UpdateEmployee(_employeeIsExists, command.FirstName, command.LastName);
            _employeeRepository.Update(employee);
        }
    }
}