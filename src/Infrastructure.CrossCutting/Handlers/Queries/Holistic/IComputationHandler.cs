namespace Infrastructure.CrossCutting.Handlers.Queries.Holistic
{
    public interface IComputationHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}