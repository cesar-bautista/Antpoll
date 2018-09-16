using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Antpoll.Domain.Core.Interfaces.Infrastructure.DataBase;
using Antpoll.Domain.Core.Interfaces.Infrastructure.DataBase.Specification;

namespace Antpoll.Infrastructure.Core.Infrastructure
{
    /// <summary>
    /// Clase base de repositorios.
    /// </summary>
    /// <typeparam name="TEntity">El tipo de entidad del repositorio.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        #region Miembros

        private IQueryableUnitOfWork _unitOfWork;
        private IDbSet<TEntity> GetSet => _unitOfWork.CreateSet<TEntity>();

        #endregion

        #region Constructor

        /// <summary>
        /// Crea una nueva instancia del repositorio.
        /// </summary>
        /// <param name="unitOfWork">Asociado con el "Unit Of Work".</param>
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        #endregion

        #region Miembros de IRepository

        public IUnitOfWork UnitOfWork => _unitOfWork;

        /// <summary>
        /// <see cref="IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(TEntity item)
        {
            if (item != null)
            {
                GetSet.Add(item);
            }
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"></param>
        public virtual void Remove(TEntity item)
        {
            if (item == null) return;
            _unitOfWork.Attach(item);
            GetSet.Remove(item);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"></param>
        public virtual void Modify(TEntity item)
        {
            if (item != null)
            {
                _unitOfWork.SetModified(item);
            }
        }

        public virtual void Modify(ICollection<TEntity> items)
        {
            //for each element in collection apply changes
            foreach (TEntity item in items)
            {
                if (item != null)
                {
                    _unitOfWork.SetModified(item);
                }
            }
        }

        public virtual void Attach(TEntity item)
        {
            _unitOfWork.Attach(item);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetSet;
        }

        public TEntity GetById(params object[] keys)
        {
            return GetSet.Find(keys);
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return GetSet.Where(predicate);
        }

        public IEnumerable<TEntity> GetBySpecification(ISpecification<TEntity> specification)
        {
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            return GetSet.Where(specification.SatisfiedBy()).AsEnumerable();
        }

        public IEnumerable<TEntity> GetPagedElements<TS>(int pageIndex, int pageCount, Expression<Func<TEntity, TS>> orderByExpression, bool ascending)
        {
            if (pageIndex < 0)
            {
                throw new ArgumentException("Invalido indice de página.", nameof(pageIndex));
            }

            if (pageCount <= 0)
            {
                throw new ArgumentException("Cantidad de páginas inválidas.", nameof(pageCount));
            }

            if (orderByExpression == null)
            {
                throw new ArgumentNullException(nameof(orderByExpression), "La expresión no puede ser null.");
            }

            return (ascending ? GetSet.OrderBy(orderByExpression).Skip(pageIndex * pageCount).Take(pageCount).ToList()
                : GetSet.OrderByDescending(orderByExpression).Skip(pageIndex * pageCount).Take(pageCount).ToList());
        }

        #endregion

        #region Miembros IDisposable

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_unitOfWork != null)
                {
                    _unitOfWork.Dispose();
                    _unitOfWork = null;
                }
            }
        }

        #endregion

    }
}
