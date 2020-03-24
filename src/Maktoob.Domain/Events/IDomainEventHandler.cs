using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace maktoob.Domain.Events
{
    public interface IDomainEventHandler<T>
        where T : IDomainEvent
    {
        void Handle(T domainEvent);
        Task HandleAsync(T domainEvent);
    }
}
