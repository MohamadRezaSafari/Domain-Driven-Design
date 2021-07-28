using System;
using System.Linq;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Services.Employees
{
    public class EmployeeHasShiftAssignment : IEmployeeHasShiftAssignment
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeHasShiftAssignment(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public bool HasEmployeeShiftAssign(long employeeId)
        {
            if (employeeRepository.HasEmployeeShiftAssign(employeeId))
                return false;
            return true;
        }
    }
}
