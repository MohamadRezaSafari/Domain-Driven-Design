namespace Framework.Core.ApplicationService
{
    public interface ICommandHandler<in TCommand> : IHandler where TCommand : Command
    {
        void Execute(TCommand command);
    }
}
