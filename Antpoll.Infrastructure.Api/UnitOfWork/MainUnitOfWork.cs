using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Antpoll.Domain.Entities;
using Antpoll.Infrastructure.Api.Context;

namespace Antpoll.Infrastructure.Api.UnitOfWork
{
    public class MainUnitOfWork : MainContext, IMainUnitOfWork
    {

        #region Miembros IDbSet

        private IDbSet<CompanyEntity> _companies;
        public IDbSet<CompanyEntity> Companies => _companies ?? (_companies = base.Set<CompanyEntity>());

        #endregion

        #region Miembros IQueryableUnitOfWork

        public IDbSet<TEntity> CreateSet<TEntity>() 
            where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item) where TEntity : class
        {
            if (Entry(item).State == EntityState.Detached)
            {
                base.Set<TEntity>().Attach(item);
            }
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            Entry(original).CurrentValues.SetValues(current);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        public Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommandAsync(sqlCommand, parameters);
        }

        #endregion

        #region Miembros de Unit Of Work

        public void SetModified<TEntity>(TEntity item) where TEntity : class
        {
            base.Entry(item).GetValidationResult();

            Entry(item).State = EntityState.Modified;
        }

        public int Commit()
        {
            return base.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return base.SaveChangesAsync();
        }

        public void RollbackChanges()
        {
            base.ChangeTracker.Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        #endregion

        #region DbContext Overrides


        public new void Dispose()
        {
            base.Dispose();
        }

        #endregion
    }
}
