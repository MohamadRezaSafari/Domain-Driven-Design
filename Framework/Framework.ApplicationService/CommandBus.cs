using System;
using Framework.Core.ApplicationService;
using Framework.Core.DependencyInjection;

namespace Framework.ApplicationService
{
    public class CommandBus : ICommandBus
    {
        private readonly IDiContainer _diContainer;

        public CommandBus(IDiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        public void Dispatch<TCommand>(TCommand command) where TCommand : Command
        {
            try
            {
                var commandHandler = _diContainer.Resolve<ICommandHandler<TCommand>>();
                var transactionCommandHandler = new TransactionCommandHandler<TCommand>(commandHandler, _diContainer);
                transactionCommandHandler.Execute(command);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
