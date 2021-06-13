using Framework.Core.ApplicationService;


namespace HR.EmployeeContext.ApplicationService.Contract.Employees
{
    public class EmployeeDeleteCommand : Command
    {
        public long EmployeeId{ get; set; }
        
    }
}
