using System;
using Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contract.EmployeeIos
{
    public class EmployeeIOCreateCommand : Command
    {
        public long EmployeeId { get; set; }
        //public Guid EmployeeId { get; set; }
        //public DateTime DateTime { get; set; }
    }
}
