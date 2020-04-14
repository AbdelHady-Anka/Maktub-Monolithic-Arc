using Maktoob.CrossCuttingConcerns.Normalizers;
using Maktoob.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Maktoob.Domain.Specifications
{
    public abstract class SingleResultSpec<TEntity> : Specification<TEntity> {}

    public class FindByIdSpec : SingleResultSpec<Entity<Guid>>
    {
        public Guid Id { get; protected set; }
        public FindByIdSpec(Guid id)
        {
            Id = id;
        }

        public override Expression<Func<Entity<Guid>, bool>> ToExpression()
        {
            return (entity) => entity.Id == Id;
        }
    }

    public class FindByNameSpec : SingleResultSpec<EntityHasName<Guid>>
    {
        public string Name { get; protected set; }
        protected readonly IKeyNormalizer _keyNormalizer;

        public FindByNameSpec(string name, IKeyNormalizer keyNormalizer)
        {
            Name = name;
            _keyNormalizer = keyNormalizer;
        }

        public override Expression<Func<EntityHasName<Guid>, bool>> ToExpression()
        {
            return (entity) => entity.NormalizedName == _keyNormalizer.Normalize(Name);
        }
    }
}
