using System;
using System.Linq.Expressions;

namespace Antpoll.Domain.Core.Interfaces.Infrastructure.DataBase.Specification
{
    public sealed class TrueSpecification<TEntity> : Specification<TEntity>
        where TEntity : class, new()
    {
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            const bool result = true;

            Expression<Func<TEntity, bool>> trueExpression = t => result;
            return trueExpression;
        }
    }
}
