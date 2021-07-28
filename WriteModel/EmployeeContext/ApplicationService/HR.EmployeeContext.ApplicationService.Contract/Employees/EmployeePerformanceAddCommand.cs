using System;
using Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contract.Employees
{
    public class EmployeePerformanceCalculateCommand : Command
    {
        public long EmployeeId { get; set; }
        public DateTime FromDate{ get; set; }
        public DateTime ToDate{ get; set; }
    }
}