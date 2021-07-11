using System;
using Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contract.Employees
{
    public class EmployeeContractCreateCommand : Command
    {
        public long EmployeeId { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UnitId { get;  set; }
    }
}
