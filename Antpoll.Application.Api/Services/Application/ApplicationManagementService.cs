using Antpoll.Application.Api.Adapters;
using Antpoll.Application.Core;
using Antpoll.Domain.Core.Interfaces.Contracts.Applications;
using Antpoll.Domain.Entities;

namespace Antpoll.Application.Api.Services.Application
{
    public class ApplicationManagementService : ManagementService<ApplicationEntity, ApplicationDto>, IApplicationManagementService
    {
        public ApplicationManagementService(IApplicationRepository applicationRepository) 
            : base(applicationRepository)
        {
        }
    }
}
