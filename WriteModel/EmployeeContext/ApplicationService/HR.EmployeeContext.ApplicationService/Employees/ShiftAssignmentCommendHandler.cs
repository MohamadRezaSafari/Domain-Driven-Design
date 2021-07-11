using System;
using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.EmployeeContext.Domain.Employees.Services.ACL;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class ShiftAssignmentCommendHandler : ICommandHandler<ShiftAssignmentCommend>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IShiftIdExists shiftIdExists;

        public ShiftAssignmentCommendHandler(IEmployeeRepository employeeRepository, IShiftIdExists shiftIdExists)
        {
            this.employeeRepository = employeeRepository;
            this.shiftIdExists = shiftIdExists;
        }


        public void Execute(ShiftAssignmentCommend command)
        {
            var employee = employeeRepository.GetByEmployeeId(command.EmployeeId);

            var AssignedShift = new ShiftAssignment(employeeRepository, employee.EmployeeId, command.StartDate, (DateTime?)null, command.ShiftSegmentId);

            employee.AssignShift(shiftIdExists, AssignedShift,command.ShiftSegmentId);
        }
    }
}
