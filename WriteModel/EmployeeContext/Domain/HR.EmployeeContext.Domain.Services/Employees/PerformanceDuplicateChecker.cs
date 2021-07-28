using System;
using System.Linq;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Services.Employees
{
    public class PerformanceDuplicateChecker: IPerformanceDuplicateChecker
    {
        private readonly IEmployeeRepository employeeRepository;

        public PerformanceDuplicateChecker(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public bool IsDuplicated(Guid employeeId, DateTime fromDate, DateTime toDate)
        {
            return employeeRepository.Any(em => em.Performance.Any(per =>
                per.EmployeeId == employeeId && per.FromDate.Date == fromDate && per.ToDate.Date == toDate));
        }
    }
}