using System;
using System.Linq;
using System.Linq.Expressions;

namespace Antpoll.Domain.Core.Interfaces.Infrastructure.DataBase.Specification
{
    public sealed class NotSpecification<TEntity> : Specification<TEntity>
        where TEntity : class, new()
    {
        private readonly Expression<Func<TEntity, bool>> _originalCriteria;
        public NotSpecification(ISpecification<TEntity> originalSpecification)
        {
            if (originalSpecification == (ISpecification<TEntity>)null)
                throw new ArgumentNullException(nameof(originalSpecification));

            _originalCriteria = originalSpecification.SatisfiedBy();
        }
        public NotSpecification(Expression<Func<TEntity, bool>> originalSpecification)
        {
            _originalCriteria = originalSpecification ?? throw new ArgumentNullException(nameof(originalSpecification));
        }
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Not(_originalCriteria.Body), _originalCriteria.Parameters.Single());
        }
    }
}
