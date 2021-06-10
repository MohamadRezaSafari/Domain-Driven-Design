namespace Framework.Core.ApplicationService
{
    public interface ICommandBus
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : Command;
    }
}