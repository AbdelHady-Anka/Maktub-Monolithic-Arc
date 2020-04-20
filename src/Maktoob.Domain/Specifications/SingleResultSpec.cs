using Maktoob.CrossCuttingConcerns.Normalizers;
using Maktoob.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Maktoob.Domain.Specifications
{
    public abstract class SingleResultSpec<TEntity> : Specification<TEntity> {}

    public class FindByIdSpec<TEntity> : SingleResultSpec<TEntity>
        where TEntity : Entity<Guid>
    {
        public Guid Id { get; protected set; }
        public FindByIdSpec(Guid id)
        {
            Id = id;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            return (entity) => entity.Id == Id;
        }
    }

    public class FindByNameSpec<TEntity> : SingleResultSpec<TEntity>
    where TEntity : EntityHasName<Guid>
    {
        public string Name { get; protected set; }
        protected readonly IKeyNormalizer _keyNormalizer;

        public FindByNameSpec(string name, IKeyNormalizer keyNormalizer)
        {
            Name = name;
            _keyNormalizer = keyNormalizer;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            return (entity) => entity.NormalizedName == _keyNormalizer.Normalize(Name);
        }
    }

    public class FindByEmailSpec<TEntity> : SingleResultSpec<TEntity>
        where TEntity : User
    {
        private readonly IKeyNormalizer _keyNormalizer;

        public FindByEmailSpec(string email, IKeyNormalizer keyNormalizer)
        {
            Email = email;
            _keyNormalizer = keyNormalizer;
        }

        public string Email { get; set; }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            return (entity) => entity.NormalizedEmail == _keyNormalizer.Normalize(Email);
        }
    }
}
