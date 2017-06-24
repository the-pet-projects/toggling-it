namespace Infrastructure.CrossCutting.Mediator
{
    using Handlers;

    public interface IMediator
    {
        TResponse Request<TResponse>(IQuery<TResponse> query);

        TResult Send<TResult>(ICommand<TResult> command);
    }
}