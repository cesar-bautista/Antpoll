using Antpoll.Application.Api.Adapters;
using Antpoll.Domain.Entities;
using AutoMapper;

namespace Antpoll.Api
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CompanyEntity, CompanyDto>();
                cfg.CreateMap<CompanyDto, CompanyEntity>();

                cfg.CreateMap<ApplicationEntity, ApplicationDto>();
                cfg.CreateMap<ApplicationDto, ApplicationEntity>();
            });
        }
    }
}