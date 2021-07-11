using Framework.Core.ApplicationService;
using Framework.Facade;
using HR.DefinitionContext.ApplicationService.Contract.Units;
using HR.DefinitionContext.Facade.Contract;

namespace HR.DefinitionContext.Facade
{
    public class UnitCommandFacade: FacadeCommandBase,IUnitCommandFacade
    {
        private readonly ICommandBus _commandBus;

        public UnitCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
            _commandBus = commandBus;
        }

        public void CreateUnit(UnitCreateCommand command)
        {
            _commandBus.Dispatch(command);
        }

        
    }
}