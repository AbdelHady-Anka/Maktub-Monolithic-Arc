using System;
using System.Collections.Generic;
using System.Text;

namespace maktoob.Domain.Entities
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
