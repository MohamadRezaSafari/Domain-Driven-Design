using System;
using Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contract.Employees
{
    public class EmployeeIOCreateCommand : Command
    {
        public long EmployeeId { get; set; }
    }
}
