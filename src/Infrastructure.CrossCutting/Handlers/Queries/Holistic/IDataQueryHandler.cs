namespace Infrastructure.CrossCutting.Handlers.Queries.Holistic
{
    public interface IDataQueryHandler<in TQuery, out TResult> where TQuery : IDataQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}