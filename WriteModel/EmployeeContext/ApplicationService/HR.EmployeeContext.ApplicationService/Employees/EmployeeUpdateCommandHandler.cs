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
        private readonly IEmployeeHasShift _employeeHasShift;

        public EmployeeUpdateCommandHandler(IEmployeeRepository employeeRepository,
            IEmployeeIsExists employeeIsExists,
            IEmployeeHasShift employeeHasShift)
        {
            _employeeRepository = employeeRepository;
            _employeeIsExists = employeeIsExists;
            _employeeHasShift = employeeHasShift;
        }
        public void Execute(EmployeeUpdateCommand command)
        {
            Employee employee = _employeeRepository.GetByEmployeeId(command.EmployeeId);
            employee.UpdateEmployee(_employeeIsExists,_employeeHasShift, command.FirstName, command.LastName);
            _employeeRepository.Update(employee);
        }
    }
}