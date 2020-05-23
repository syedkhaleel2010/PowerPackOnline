using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIMS.API.Repositories;
using PowerPack.Common.ViewModels;

namespace SIMS.API.Services
{
    public class EmailSettingsService : IEmailSettingsService
    {
        private readonly IEmailSettingsRepository _emailSettingsRepository;
        public EmailSettingsService(IEmailSettingsRepository emailSettingsRepository)
        {
            _emailSettingsRepository = emailSettingsRepository;
        }
        public Task<EmailSettingsView> GetEmailSettings()
        {
            return _emailSettingsRepository.GetEmailSettings();
        }

        public Task<SystemLanguage> GetSchoolCurrentLanguage(int SchoolId)
        {
            return _emailSettingsRepository.GetSchoolCurrentLanguage(SchoolId);
        }

        public bool SetSchoolCurrentLanguage(int languageId,int schoolId)
        {
            return _emailSettingsRepository.SetSchoolCurrentLanguage(languageId,schoolId);
        }
    }
}
