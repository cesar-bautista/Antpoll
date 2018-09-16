using Antpoll.Application.Api.Adapters;
using Antpoll.Application.Core;

namespace Antpoll.Application.Api.Services.Company
{
    public interface ICompanyManagementService : IManagementService<Domain.Entities.CompanyEntity, CompanyDto>
    {
        CompanyDto AddCompany(Domain.Entities.CompanyEntity item, string source);

        CompanyDto ModifyCompany(Domain.Entities.CompanyEntity item);

        int Cancel(byte companyId);
    }
}
