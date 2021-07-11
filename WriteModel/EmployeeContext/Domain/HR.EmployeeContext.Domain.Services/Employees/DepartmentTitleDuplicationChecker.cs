using System;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Services.Employees
{
    public class DepartmentTitleDuplicationChecker:IDepartmentTitleDuplicationChecker
    {
        private readonly IEmployeeRepository employeeRepository;

        public DepartmentTitleDuplicationChecker(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        //public bool IsDuplicated(Guid id, string title)
        //{
        //    return employeeRepository.Contains(g => g.Id != id );
        //}
    }
}
