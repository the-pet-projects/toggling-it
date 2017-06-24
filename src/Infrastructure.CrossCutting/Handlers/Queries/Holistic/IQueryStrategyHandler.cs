namespace Infrastructure.CrossCutting.Handlers.Queries.Holistic
{
    public interface IQueryStrategyHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}