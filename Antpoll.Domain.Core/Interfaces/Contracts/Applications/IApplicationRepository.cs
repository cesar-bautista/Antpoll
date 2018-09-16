using Antpoll.Domain.Core.Interfaces.Infrastructure.DataBase;
using Antpoll.Domain.Entities;

namespace Antpoll.Domain.Core.Interfaces.Contracts.Applications
{
    public interface IApplicationRepository : IRepository<ApplicationEntity>
    {
    }
}
