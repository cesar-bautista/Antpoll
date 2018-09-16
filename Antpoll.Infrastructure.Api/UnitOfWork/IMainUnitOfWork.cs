using System.Data.Entity;
using Antpoll.Domain.Entities;
using Antpoll.Infrastructure.Core.Infrastructure;

namespace Antpoll.Infrastructure.Api.UnitOfWork
{
    public interface IMainUnitOfWork : IQueryableUnitOfWork
    {
        IDbSet<CompanyEntity> Companies { get; }
    }
}
