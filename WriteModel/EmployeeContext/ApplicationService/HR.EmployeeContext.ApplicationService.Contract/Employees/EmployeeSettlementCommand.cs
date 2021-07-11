using Framework.Core.ApplicationService;
using System;

namespace HR.EmployeeContext.ApplicationService.Contract.Employees
{
    public class EmployeeSettlementCommand : Command
    {
        public long EmployeeId { get; set; }
        public DateTime SettlementDate { get; set; }
    }
}
