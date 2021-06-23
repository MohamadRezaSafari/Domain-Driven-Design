using System;
using System.Collections.Generic;
using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class ShiftAssignmentCommendHandler : ICommandHandler<ShiftAssignmentCommend>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeHasShift _employeeHasShift;

        public ShiftAssignmentCommendHandler(IEmployeeRepository employeeRepository,
            IEmployeeHasShift employeeHasShift)
        {
            this.employeeRepository = employeeRepository;
            _employeeHasShift = employeeHasShift;
        }

        public void Execute(ShiftAssignmentCommend command)
        {
            var employee = employeeRepository.GetByEmployeeId(command.EmployeeId);

            var AssignedShift = new ShiftAssignment(employee.EmployeeId, command.StartTime, command.EndTime, command.ShiftId);

            //employee.ShiftAssignment.Add(AssignedShift);

            employee.AssignShift(_employeeHasShift, AssignedShift);

            //  employeeRepository.Update(employee);
        }
    }
}
