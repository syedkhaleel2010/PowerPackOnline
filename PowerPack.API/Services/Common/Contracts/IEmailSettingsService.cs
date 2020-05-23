using PowerPack.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface IEmailSettingsService
    {
        Task<EmailSettingsView> GetEmailSettings();
        Task<SystemLanguage> GetSchoolCurrentLanguage(int SchoolId);
        bool SetSchoolCurrentLanguage(int languageId,int SchoolId);
    }
}
