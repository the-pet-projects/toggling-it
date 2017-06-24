namespace Infrastructure.CrossCutting.Handlers.Commands.Holistic
{
    public interface ICommandStrategyHandler<in TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}