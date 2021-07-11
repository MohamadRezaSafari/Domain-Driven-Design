using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using System;
using System.Linq;
using HR.EmployeeContext.Domain.Employees.Services.ACL;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeIOCreateCommandHandler : ICommandHandler<EmployeeIOCreateCommand>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IShiftRepositoryACL shiftRepositoryAcl;

        public EmployeeIOCreateCommandHandler(IEmployeeRepository employeeRepository, IEmployeeIoIsValidAclService employeeIoIsValidAclService, IShiftRepositoryACL shiftRepositoryAcl)
        {
            this.employeeRepository = employeeRepository;
            this.shiftRepositoryAcl = shiftRepositoryAcl;
        }


        public void Execute(EmployeeIOCreateCommand command)
        {
            var employee = employeeRepository.GetByEmployeeId(command.EmployeeId);
            var lastShiftAssigned = employee.ShiftAssignments.OrderByDescending(e => e.StartDate).FirstOrDefault();
            var lastEmployeeContract = employee.EmployeeContracts.OrderByDescending(e => e.StartDate).FirstOrDefault();
            var shift = shiftRepositoryAcl.GetShiftByShiftSegmentId(lastShiftAssigned.ShiftSegmentId.Value);
            var shiftSegments = shiftRepositoryAcl.GetShiftSegments(shift.Id);


            var employeeIo = new EmployeeIo(employee.Id, DateTime.Now);
            //employee.AddEmployeeIo(employeeIoIsValidAclService, employeeIo,command.EmployeeId, DateTime.Now,ShiftAssignment lastAssigned);
            employee.AddEmployeeIo( employeeIo, lastShiftAssigned, lastEmployeeContract, shift, shiftSegments);
        }
    }
}
