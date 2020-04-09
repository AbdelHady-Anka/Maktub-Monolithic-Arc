using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace maktoob.Application.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
