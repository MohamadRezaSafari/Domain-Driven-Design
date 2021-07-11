using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees.Services;


namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeReHireCommandHandler : ICommandHandler<EmployeeReHireCommand>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeIsExists employeeIsExists;

        public EmployeeReHireCommandHandler(IEmployeeRepository employeeRepository, IEmployeeIsExists employeeIsExists)
        {
            this.employeeRepository = employeeRepository;
            this.employeeIsExists = employeeIsExists;
        }

        public void Execute(EmployeeReHireCommand command)
        {
            var employee = employeeRepository.GetByEmployeeId(command.EmployeeId);
            employee.EmployeeReHire(employeeIsExists);
        }
    }
}
