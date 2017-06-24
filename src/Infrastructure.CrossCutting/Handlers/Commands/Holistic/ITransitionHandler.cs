namespace Infrastructure.CrossCutting.Handlers.Commands.Holistic
{
    public interface ITransitionHandler<in TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}