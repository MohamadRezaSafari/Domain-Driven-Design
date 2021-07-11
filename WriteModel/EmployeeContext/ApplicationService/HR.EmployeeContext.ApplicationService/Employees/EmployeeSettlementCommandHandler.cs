using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeSettlementCommandHandler : ICommandHandler<EmployeeSettlementCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeSettlementCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Execute(EmployeeSettlementCommand command)
        {
            var employee = _employeeRepository.GetByEmployeeId(command.EmployeeId);
            employee.EmployeeSettlement(command.SettlementDate);
        }
    }
}
