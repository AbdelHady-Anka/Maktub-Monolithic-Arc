using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace maktoob.Domain.Repositories
{
    public interface IMongoDbCollection<TCollection> where TCollection : class
    {
        void Add(TCollection item);
        void Remove(TCollection item);
        TCollection Find(params object[] keyValues);
        IEnumerable<TCollection> All();
        IEnumerable<TCollection> Where(Func<TCollection, bool> predicate);
    }
}