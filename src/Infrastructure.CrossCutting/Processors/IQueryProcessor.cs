namespace Infrastructure.CrossCutting.Processors
{
    using System.Net;
    using Handlers;

    public interface IQueryProcessor
    {
        TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}