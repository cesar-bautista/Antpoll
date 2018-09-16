using System;
using Antpoll.Application.Api.Services.Application;
using Antpoll.Application.Api.Services.Company;
using Antpoll.Domain.Core.Interfaces.Contracts.Applications;
using Antpoll.Domain.Core.Interfaces.Contracts.Companies;
using Antpoll.Infrastructure.Api.Repositories;
using Antpoll.Infrastructure.Api.UnitOfWork;
using Unity;

namespace Antpoll.Api
{
    public class UnityConfig
    {
        #region Unity Container

        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        private static IUnityContainer GetConfiguredContainer => Container.Value;

        public static T Resolve<T>() where T : class
        {
            return GetConfiguredContainer.Resolve<T>();
        }

        #endregion

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IMainUnitOfWork, MainUnitOfWork>();

            container.RegisterType<IApplicationRepository, ApplicationRepository>();
            container.RegisterType<ICompanyManagementService, CompanyManagementService>();

            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<IApplicationManagementService, ApplicationManagementService>();
        }
    }
}