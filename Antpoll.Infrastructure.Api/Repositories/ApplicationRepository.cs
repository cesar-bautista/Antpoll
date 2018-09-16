using Antpoll.Domain.Core.Interfaces.Contracts.Applications;
using Antpoll.Domain.Entities;
using Antpoll.Infrastructure.Api.UnitOfWork;
using Antpoll.Infrastructure.Core.Infrastructure;

namespace Antpoll.Infrastructure.Api.Repositories
{
    public class ApplicationRepository : Repository<ApplicationEntity>, IApplicationRepository
    {
        public ApplicationRepository(IMainUnitOfWork unitofwork)
            : base(unitofwork)
        {
        }
    }
}
