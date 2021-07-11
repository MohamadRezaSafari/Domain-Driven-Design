using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeContractCreateCommandHandler : ICommandHandler<EmployeeContractCreateCommand>
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeContractCreateCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void Execute(EmployeeContractCreateCommand command)
        {
            var employee = employeeRepository.GetByEmployeeId(command.EmployeeId);

            var conclusionContract = new EmployeeContract(employeeRepository,employee.EmployeeId,  command.EndDate,command.UnitId);

            employee.ConcludeEmployeeContract(employeeRepository,command.EmployeeId,conclusionContract);
        }
    }
}
