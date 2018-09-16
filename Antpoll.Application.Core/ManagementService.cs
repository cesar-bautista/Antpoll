using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Antpoll.Crosscutting.Logging;
using Antpoll.Domain.Core.Interfaces.Infrastructure.DataBase;
using AutoMapper;

namespace Antpoll.Application.Core
{
    public class ManagementService<TEntity, TEntityDto> : IManagementService<TEntity, TEntityDto>
        where TEntity : class, new()
        where TEntityDto : class, new()
    {
        private readonly Logger _log;
        private readonly IRepository<TEntity> _repository;

        public ManagementService(IRepository<TEntity> repository)
        {
            _log = new Logger();
            _repository = repository;
        }

        public TEntityDto Add(TEntity entity)
        {
            IUnitOfWork unitOfWork = _repository.UnitOfWork;
            TEntityDto entityDto = null;

            try
            {
                _repository.Add(entity);
                unitOfWork.Commit();
                entityDto = Mapper.Map<TEntityDto>(entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }

            return entityDto;
        }

        public Task<TEntityDto> AddAsync(TEntity entity)
        {
            return Task.Run(() => Add(entity));
        }

        public TEntityDto Modify(TEntity entity)
        {
            var unitOfWork = _repository.UnitOfWork;
            TEntityDto entityDto = null;

            try
            {
                _repository.Modify(entity);
                unitOfWork.Commit();
                entityDto = Mapper.Map<TEntityDto>(entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }

            return entityDto;
        }

        public Task<TEntityDto> ModifyAsync(TEntity entity)
        {
            return Task.Run(() => Modify(entity));
        }

        public int Modify(ICollection<TEntity> items)
        {
            var unitOfWork = _repository.UnitOfWork;
            var result = 0;

            try
            {
                _repository.Modify(items);
                result = unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }

            return result;
        }

        public Task<int> ModifyAsync(ICollection<TEntity> items)
        {
            return Task.Run(() => Modify(items));
        }

        public int Remove(params object[] keys)
        {
            var unitOfWork = _repository.UnitOfWork;
            var result = 0;

            try
            {
                var entity = _repository.GetById(keys);

                _repository.Remove(entity);
                result = unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }

            return result;
        }

        public Task<int> RemoveAsync(params object[] keys)
        {
            return Task.Run(() => Remove(keys));
        }

        public TEntityDto GetById(params object[] keys)
        {
            TEntityDto entityDto = null;

            try
            {
                var entity = _repository.GetById(keys);

                entityDto = Mapper.Map<TEntityDto>(entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }
            return entityDto;
        }

        public IEnumerable<TEntityDto> GetAll()
        {
            IEnumerable<TEntityDto> result = null;
            try
            {
                var list = _repository.GetAll();

                result = Mapper.Map<IEnumerable<TEntityDto>>(list);                
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }
            return result;
        }

        public IEnumerable<TEntityDto> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntityDto> result = null;
            try
            {
                var list = _repository.FindBy(predicate);

                result = Mapper.Map<IEnumerable<TEntityDto>>(list);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }
            return result;
        }
    }
}
