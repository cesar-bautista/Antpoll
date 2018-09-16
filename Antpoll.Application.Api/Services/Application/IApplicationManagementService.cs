using Antpoll.Application.Api.Adapters;
using Antpoll.Application.Core;
using Antpoll.Domain.Entities;

namespace Antpoll.Application.Api.Services.Application
{
    public interface IApplicationManagementService : IManagementService<ApplicationEntity, ApplicationDto>
    {
    }
}
