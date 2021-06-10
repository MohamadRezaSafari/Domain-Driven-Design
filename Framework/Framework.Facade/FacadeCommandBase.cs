using Framework.Core.ApplicationService;
using Framework.Core.Facade;

namespace Framework.Facade
{
    public abstract class FacadeCommandBase : ICommandFacade
    {
        protected FacadeCommandBase(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }

        public ICommandBus CommandBus { get; }
    }
}