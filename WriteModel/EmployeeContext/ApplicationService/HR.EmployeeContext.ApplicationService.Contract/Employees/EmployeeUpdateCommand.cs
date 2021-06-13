using Framework.Core.ApplicationService;


namespace HR.EmployeeContext.ApplicationService.Contract.Employees
{
    public class EmployeeUpdateCommand : Command
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
