using System.Threading.Tasks;
using Maktoob.Domain.Entities;

namespace Maktoob.Domain.Events
{
    public class UserCreatedEvent : IDomainEvent
    {
        public User User { get; set; }
        public UserCreatedEvent(User user)
        {
            this.User = user;
        }

        public class Handler : IDomainEventHandler<UserCreatedEvent>
        {
            public Task HandleAsync(UserCreatedEvent domainEvent)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}