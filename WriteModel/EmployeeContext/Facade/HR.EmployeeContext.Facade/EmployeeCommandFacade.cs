using Framework.Core.ApplicationService;
using Framework.Facade;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Facade.Contract;

namespace HR.EmployeeContext.Facade
{
    public class EmployeeCommandFacade : FacadeCommandBase, IEmployeeCommandFacade
    {
        public EmployeeCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void CreateEmployee(EmployeeCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }

        
    }
}