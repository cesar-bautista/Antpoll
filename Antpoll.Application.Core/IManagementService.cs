using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Antpoll.Application.Core
{
    public interface IManagementService<TEntity, TEntityDto>
        where TEntity : class, new()
        where TEntityDto : class, new()
    {
        TEntityDto Add(TEntity entity);

        Task<TEntityDto> AddAsync(TEntity entity);

        TEntityDto Modify(TEntity entity);

        Task<TEntityDto> ModifyAsync(TEntity entity);

        int Modify(ICollection<TEntity> items);

        Task<int> ModifyAsync(ICollection<TEntity> items);

        int Remove(params object[] keys);

        Task<int> RemoveAsync(params object[] keys);

        TEntityDto GetById(params object[] keys);

        IEnumerable<TEntityDto> GetAll();

        IEnumerable<TEntityDto> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}
