using System;
using Framework.Core.ApplicationService;
using Framework.Core.DependencyInjection;

namespace Framework.ApplicationService
{
    public class TransactionCommandHandler<TCommand>:ICommandHandler<TCommand> where TCommand:Command
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly IDiContainer _diContainer;

        public TransactionCommandHandler(ICommandHandler<TCommand> commandHandler, IDiContainer diContainer)
        {
            _commandHandler = commandHandler;
            _diContainer = diContainer;
        }
        public void Execute(TCommand command)
        {
            var unitOfWork = _diContainer.Resolve<IUnitOfWork>();
            try
            {
                _commandHandler.Execute(command);
                unitOfWork.Commit();
            }
            catch(Exception e)
            {
                
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}