using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.EmployeeContext.Domain.Employees.Services.ACL;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeCreateCommandHandler : ICommandHandler<EmployeeCreateCommand>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeUnitIdExistsAclService _employeeUnitIdValidateAclService;

        public EmployeeCreateCommandHandler(IEmployeeRepository employeeRepository
            , IEmployeeUnitIdExistsAclService employeeUnitIdValidateAclService)
        {
            this.employeeRepository = employeeRepository;
            _employeeUnitIdValidateAclService = employeeUnitIdValidateAclService;
        }

        public void Execute(EmployeeCreateCommand command)
        {
            Employee employee = new Employee(employeeRepository, command.FirstName, command.LastName);
            employee.AddUnitId(_employeeUnitIdValidateAclService, command.UnitId);
            this.employeeRepository.Create(employee);
        }
    }
}
