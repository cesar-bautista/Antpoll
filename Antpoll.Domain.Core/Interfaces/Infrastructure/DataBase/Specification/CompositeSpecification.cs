namespace Antpoll.Domain.Core.Interfaces.Infrastructure.DataBase.Specification
{
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
        where TEntity : class, new()
    {
        public abstract ISpecification<TEntity> LeftSideSpecification { get; }
        public abstract ISpecification<TEntity> RightSideSpecification { get; }
    }
}
