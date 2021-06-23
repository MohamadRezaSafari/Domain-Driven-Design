using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.EmployeeIos;
using HR.EmployeeContext.Domain.EmployeeIos;
using HR.EmployeeContext.Domain.EmployeeIos.Services;
using HR.EmployeeContext.Domain.Employees.Services;
using System;

namespace HR.EmployeeContext.ApplicationService.EmployeeIos
{
    public class EmployeeIOCreateCommandHandler : ICommandHandler<EmployeeIOCreateCommand>
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeIOCreateCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Execute(EmployeeIOCreateCommand command)
        {
            var employee = employeeRepository.GetByEmployeeId(command.EmployeeId);
            var employeeIo = new EmployeeIo(employee.Id, DateTime.Now);
            employee.AddEmployeeIo(employeeIo);
            //var employeeIO = new EmployeeIo(command.EmployeeId,command.DateTime);
            //employeeIoRepository.Create(employeeIO);
        }
    }
}
