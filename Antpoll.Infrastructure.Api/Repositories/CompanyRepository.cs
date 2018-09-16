using Antpoll.Domain.Core.Interfaces.Contracts.Companies;
using Antpoll.Domain.Entities;
using Antpoll.Infrastructure.Api.UnitOfWork;
using Antpoll.Infrastructure.Core.Infrastructure;

namespace Antpoll.Infrastructure.Api.Repositories
{
    public class CompanyRepository : Repository<CompanyEntity>, ICompanyRepository
    {
        public CompanyRepository(IMainUnitOfWork unitofwork)
            : base(unitofwork)
        { }
    }
}
