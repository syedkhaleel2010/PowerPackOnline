using PowerPack.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.Services
{
    public interface ICommonService
    {
        EmailSettingsView GetEmailSettings();
        SystemLanguage GetStoreCurrentLanguage(int StoreId);
        bool SetStoreCurrentLanguage(int languageId, int StoreId);
    }
}
