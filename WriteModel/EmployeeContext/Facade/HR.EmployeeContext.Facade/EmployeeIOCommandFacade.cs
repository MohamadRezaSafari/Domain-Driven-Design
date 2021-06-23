using Framework.Core.ApplicationService;
using Framework.Facade;
using HR.EmployeeContext.ApplicationService.Contract.EmployeeIos;
using HR.EmployeeContext.Facade.Contract;

namespace HR.EmployeeContext.Facade
{
    public class EmployeeIOCommandFacade : FacadeCommandBase, IEmployeeIOCommandFacade
    {
        public EmployeeIOCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }
        public void CreateEmployeeIO(EmployeeIOCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }

    }
}
