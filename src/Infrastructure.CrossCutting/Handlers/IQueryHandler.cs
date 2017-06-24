namespace Infrastructure.CrossCutting.Handlers
{
    public interface IQueryHandler<in TQuery, out TResponse>
        where TQuery : IQuery<TResponse>
    {
        TResponse Handler(TQuery query);
    }
}