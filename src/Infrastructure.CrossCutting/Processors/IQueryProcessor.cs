namespace Infrastructure.CrossCutting.Processors
{
    using System.Net;
    using Handlers;
    using Handlers.Queries;

    public interface IQueryProcessor
    {
        TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}