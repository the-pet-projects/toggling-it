namespace Infrastructure.CrossCutting.Handlers.Commands.Holistic
{
    public interface IDataCommandHandler<in TCommand>
        where TCommand : IDataCommand
    {
        void Handle(TCommand command);
    }
}