namespace Infrastructure.CrossCutting.Mediator
{
    using Handlers.Commands;
    using Handlers.Queries;

    public class Mediator : IMediator
    {
        public TResponse Request<TResponse>(IQuery<TResponse> query)
        {
            throw new System.NotImplementedException();
        }

        public TResult Send<TResult>(ICommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}