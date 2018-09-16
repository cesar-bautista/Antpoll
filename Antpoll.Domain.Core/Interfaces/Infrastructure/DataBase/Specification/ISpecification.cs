using System;
using System.Linq.Expressions;

namespace Antpoll.Domain.Core.Interfaces.Infrastructure.DataBase.Specification
{
    public interface ISpecification<TEntity>
        where TEntity : class, new()
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
