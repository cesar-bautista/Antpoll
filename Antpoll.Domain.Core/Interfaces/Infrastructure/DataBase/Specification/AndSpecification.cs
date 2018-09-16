using System;
using System.Linq.Expressions;

namespace Antpoll.Domain.Core.Interfaces.Infrastructure.DataBase.Specification
{
    public sealed class AndSpecification<TEntity> : CompositeSpecification<TEntity>
        where TEntity : class, new()
    {
        private readonly ISpecification<TEntity> _rightSideSpecification;
        private readonly ISpecification<TEntity> _leftSideSpecification;

        public AndSpecification(ISpecification<TEntity> leftSide, ISpecification<TEntity> rightSide)
        {
            this._leftSideSpecification = leftSide ?? throw new ArgumentNullException(nameof(leftSide));
            this._rightSideSpecification = rightSide ?? throw new ArgumentNullException(nameof(rightSide));
        }

        public override ISpecification<TEntity> LeftSideSpecification => _leftSideSpecification;

        public override ISpecification<TEntity> RightSideSpecification => _rightSideSpecification;

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            var left = _leftSideSpecification.SatisfiedBy();
            var right = _rightSideSpecification.SatisfiedBy();

            return (left.And(right));
        }
    }
}
