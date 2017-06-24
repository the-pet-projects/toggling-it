namespace Infrastructure.CrossCutting.Processors
{
    using System;
    using System.Diagnostics;
    using Handlers;
    using Handlers.Queries;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly IServiceProvider container;

        public QueryProcessor(IServiceProvider container)
        {
            this.container = container;
        }

        [DebuggerStepThrough]
        public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            //throw new NotImplementedException();
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = container.GetService(handlerType);

            return handler.Handler((dynamic)query);
        }
    }
}