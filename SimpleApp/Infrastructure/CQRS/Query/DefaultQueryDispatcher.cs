using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Infrastructure.CQRS.Query
{
    public interface IQuery { }

    public interface IQueryResult { }

    public interface IQueryDispatcher
    {
        Task<TQueryResult> Execute<TQuery, TQueryResult>(TQuery query)
            where TQuery : class, IQuery
            where TQueryResult : class, IQueryResult, new();
    }

    public interface IQueryHandler<in TQuery, TQueryResult>
        where TQuery : class, IQuery
        where TQueryResult : class, IQueryResult
    {
        Task<TQueryResult> HandleAsync(TQuery query);
    }

    public class DefaultQueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _service;

        public DefaultQueryDispatcher(IServiceProvider service)
        {
            this._service = service;
        }

        public async Task<TQueryResult> Execute<TQuery, TQueryResult>(TQuery query)
            where TQuery : class, IQuery
            where TQueryResult : class, IQueryResult, new()
        {
            if (query == null) { throw new ArgumentNullException(); }

            var handler = (IQueryHandler<TQuery, TQueryResult>)_service.GetService(typeof(IQueryHandler<TQuery, TQueryResult>));
            var result = await handler.HandleAsync(query);
            return result;
        }
    }
}