using System;
using System.Linq.Expressions;

namespace Antpoll.Domain.Core.Interfaces.Infrastructure.DataBase.Specification
{
    public sealed class DirectSpecification<TEntity> : Specification<TEntity>
        where TEntity : class, new()
    {
        private readonly Expression<Func<TEntity, bool>> _matchingCriteria;

        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            _matchingCriteria = matchingCriteria ?? throw new ArgumentNullException(nameof(matchingCriteria));
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return _matchingCriteria;
        }
    }
}
