using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;

namespace maktoob.Domain.Entities
{
    public class Chat : Chat<ObjectId>
    {

    }
    public class Chat<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}