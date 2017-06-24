namespace Infrastructure.CrossCutting.Mediator
{
    using Handlers.Commands;
    using Handlers.Queries;

    public interface IMediator
    {
        TResponse Request<TResponse>(IQuery<TResponse> query);

        TResult Send<TResult>(ICommand command);
    }
}