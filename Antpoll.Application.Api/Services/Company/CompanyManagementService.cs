using System;
using Antpoll.Application.Api.Adapters;
using Antpoll.Application.Core;
using Antpoll.Crosscutting.Logging;
using Antpoll.Domain.Core.Configuration;
using Antpoll.Domain.Core.Interfaces.Contracts.Companies;
using Antpoll.Domain.Core.Interfaces.Infrastructure.DataBase;
using AutoMapper;

namespace Antpoll.Application.Api.Services.Company
{
    public class CompanyManagementService : ManagementService<Domain.Entities.CompanyEntity, CompanyDto>, ICompanyManagementService
    {
        #region Variables

        private readonly Logger _log;
        private readonly ICompanyRepository _companyRepository;

        #endregion

        #region Builder

        public CompanyManagementService(ICompanyRepository companyRepository) 
            : base(companyRepository)
        {
            _log = new Logger();
            _companyRepository = companyRepository;
        }

        #endregion

        #region Write

        public CompanyDto AddCompany(Domain.Entities.CompanyEntity item, string source)
        {
            var unitOfWork = _companyRepository.UnitOfWork;
            CompanyDto entityDto;

            try
            {
                _companyRepository.Add(item);
                unitOfWork.Commit();
                entityDto = Mapper.Map<CompanyDto>(item);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace, source);
                throw new Exception(ConfigManager.MsgAddError);
            }

            return entityDto;
        }

        public int Cancel(byte companyId)
        {
            IUnitOfWork unitOfWork = _companyRepository.UnitOfWork;
            int result = 0;

            try
            {
                var entity = _companyRepository.GetById(companyId);
                entity.Canceled = true;

                _companyRepository.Modify(entity);
                result = unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
            }

            return result;
        }

        public CompanyDto ModifyCompany(Domain.Entities.CompanyEntity item)
        {
            var unitOfWork = _companyRepository.UnitOfWork;
            CompanyDto entityDto;
            
            try
            {
                var origin = _companyRepository.GetById(item.CompanyId);

                if (origin == null)
                {
                    throw new ArgumentNullException(nameof(origin));
                }
                origin.Code = item.Code;
                origin.BusinessName = item.BusinessName;
                origin.AlternateCode = item.AlternateCode;
                origin.Active = item.Active;

                _companyRepository.Modify(origin);
                unitOfWork.Commit();
                entityDto = Mapper.Map<CompanyDto>(origin);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex.Source, ex.StackTrace);
                throw new Exception(ConfigManager.MsgAddError);
            }

            return entityDto;
        }

        #endregion

    }
}
