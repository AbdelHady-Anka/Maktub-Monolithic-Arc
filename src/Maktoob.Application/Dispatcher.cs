using Maktoob.Application.Commands;
using Maktoob.Application.Queries;
using System;
using System.Threading.Tasks;

namespace Maktoob.Application
{
    public class Dispatcher
    {
        private readonly IServiceProvider _provider;

        public Dispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }


        public async Task DispatchAsync(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            await handler.HandleAsync((dynamic)command);
        }

        public async Task<T> DispatchAsync<T>(IQuery<T> query) where T : class
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = await handler.HandleAsync((dynamic)query);

            return result;
        }
    }
}