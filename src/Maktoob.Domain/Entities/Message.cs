using System;

namespace maktoob.Domain.Entities
{
    public class Message : Message<string>
    {

    }
    public class Message<TKey> where TKey : IEquatable<TKey>
    {
        public DateTime Sent { get; set; }
        public DateTime Read { get; set; }
        public DateTime Delivered { get; set; }
        public TKey SenderId { get; set; }
    }
}