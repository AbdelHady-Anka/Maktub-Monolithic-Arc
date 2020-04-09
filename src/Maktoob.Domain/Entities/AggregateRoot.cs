using System;
using System.Collections.Generic;
using System.Text;

namespace Maktoob.Domain.Entities
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
