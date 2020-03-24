using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;

namespace maktoob.Domain.Entities
{
    public class Chat : Chat<ObjectId>
    {

    }
    public class Chat<TKey> : AggregateRoot<TKey>
        where TKey : IEquatable<TKey>
    {
        public IEnumerable<Message> Messages { get; set; }
    }
}