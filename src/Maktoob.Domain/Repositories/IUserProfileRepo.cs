using System;
using maktoob.Domain.Entities;
using MongoDB.Bson;

namespace maktoob.Domain.Repositories
{
    public interface IUserProfile : IUserProfileRepo<ObjectId>
    {

    }
    public interface IUserProfileRepo<TKey> where TKey : IEquatable<TKey>
    {
        void Add(UserProfile userProfile);
        UserProfile<TKey> GetProfile(TKey userId);
        void Remove(TKey userId);
    }
}