using System;
using Framework.Core.ApplicationService;


namespace HR.EmployeeContext.ApplicationService.Contract.Employees
{
    public class EmployeeCreateCommand : Command
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UnitId { get; set; }
    }
}
