using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace maktoob.Domain.Entities
{
    public class ChatList : ChatList<ObjectId>
    {

    }
    public class ChatList<TKey> : AggregateRoot<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey UserId { get; set; }
        public IEnumerable<Chat> Chats { get; set; }
    }
}