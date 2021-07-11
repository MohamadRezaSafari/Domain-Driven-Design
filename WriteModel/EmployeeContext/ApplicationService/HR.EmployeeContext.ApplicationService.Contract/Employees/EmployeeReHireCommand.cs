using System;
using Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contract.Employees
{
    public class EmployeeReHireCommand : Command
    {
        public long EmployeeId { get; set; }
    }
}
