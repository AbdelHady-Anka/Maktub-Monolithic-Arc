using System;
using MongoDB.Bson;

namespace maktoob.Domain.Entities
{
    public class UserProfile : UserProfile<ObjectId>
    {

    }
    public class UserProfile<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public TKey UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Photo ProfilePhoto { get; set; }
        public Photo CoverPhoto { get; set; }
        public Location Location { get; set; }
    }
}