using Maktoob.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maktoob.Application.Decorators
{
    class DatabaseRetryDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;

        public DatabaseRetryDecorator(ICommandHandler<TCommand> handler)
        {
            _handler = handler;
        }
        public async Task HandleAsync(TCommand command)
        {
            await _handler.HandleAsync(command);
        }
    }
}
