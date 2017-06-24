namespace Infrastructure.CrossCutting.Mediator
{
    using Handlers;

    public class Mediator : IMediator
    {
        public TResponse Request<TResponse>(IQuery<TResponse> query)
        {
            throw new System.NotImplementedException();
        }

        public TResult Send<TResult>(ICommand<TResult> command)
        {
            throw new System.NotImplementedException();
        }
    }
}