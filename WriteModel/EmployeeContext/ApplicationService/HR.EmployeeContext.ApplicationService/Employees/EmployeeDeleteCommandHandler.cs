using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeDeleteCommandHandler : ICommandHandler<EmployeeDeleteCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeIsExists _employeeIsExists;

        public EmployeeDeleteCommandHandler(IEmployeeRepository employeeRepository, IEmployeeIsExists employeeIsExists)
        {
            _employeeRepository = employeeRepository;
            _employeeIsExists = employeeIsExists;
        }
        public void Execute(EmployeeDeleteCommand command)
        {
            var employee = _employeeRepository.GetByEmployeeId(command.EmployeeId);
            employee?.DeleteEmployee(_employeeIsExists);
            _employeeRepository.Update(employee);
            
        }
    }
}
