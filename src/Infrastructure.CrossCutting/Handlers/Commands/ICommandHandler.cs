namespace Infrastructure.CrossCutting.Handlers.Commands
{
    public interface ICommandHandler<in TCommand, out TResult>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}