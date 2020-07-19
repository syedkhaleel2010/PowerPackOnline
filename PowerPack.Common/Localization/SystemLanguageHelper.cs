using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PowerPack.Common.DataAccess;
using PowerPack.Common.Helpers;
using PowerPack.Common.Helpers.Extensions;
using PowerPack.Common.Services;
using PowerPack.Common.ViewModels;

namespace PowerPack.Common.Helpers
{
    public class SystemLanguageHelper
    {
        private static IEnumerable<SystemLanguage> _languages = null;

        public static IEnumerable<SystemLanguage> SystemLanguages
        {
            get
            {
                if (_languages == null)
                {
                    //DataHelper _datahelper = new DataHelper();
                    //_languages = _datahelper.CopyDataReaderToObjectList<SystemLanguage>(_datahelper.GetSqlDataReader("Admin.GetSystemLanguages"));
                    var langList = new List<SystemLanguage>();
                    langList.Add(new SystemLanguage { SystemLanguageId = 1, SystemLanguageCode = "EN", SystemLanguageName = "English", CultureString = "en-GB", IsEnabled = true });
                    langList.Add(new SystemLanguage { SystemLanguageId = 2, SystemLanguageCode = "AR", SystemLanguageName = "Arabic", CultureString = "ar-GB", IsEnabled = true });
                    return langList;

                }
                return _languages;
            }
        }
        public static SystemLanguage GetStoreCurrentLanguage()
        {
            //DataHelper _datahelper = new DataHelper();
            //DataParameter parameter = new DataParameter("@StoreId", SqlDbType.BigInt, PowerPackConfiguration.Instance.DefaultStoreId);
            //string query = "SELECT TOP 1 SystemLanguageId FROM Admin.StoreSettings WHERE StoreId = @StoreId";
            //int currentLanguageId = _datahelper.GetScalarValue(query, CommandType.Text, parameter).ToInteger();
            //if(currentLanguageId > 0)
            //    return SystemLanguages.FirstOrDefault(x => x.SystemLanguageId == currentLanguageId);
            //else
            ICommonService _commonService = new CommonService();
            int currentLanguageId = _commonService.GetStoreCurrentLanguage(Convert.ToInt32(SessionHelper.CurrentSession.StoreId)).SystemLanguageId;
            if (currentLanguageId > 0)
                return SystemLanguages.FirstOrDefault(x => x.SystemLanguageId == currentLanguageId);
            else
                return new SystemLanguage(1, "EN");
        }

        public static bool SetStoreCurrentLanguage(int languageId)
        {
            //DataHelper _datahelper = new DataHelper();
            //IList<DataParameter> parameters = new List<DataParameter>();
            //parameters.Add(new DataParameter("@StoreId", SqlDbType.BigInt, PowerPackConfiguration.Instance.DefaultStoreId));
            //parameters.Add(new DataParameter("@SystemLanguageId", SqlDbType.Int, languageId));
            //return _datahelper.ExecuteNonQuery("Admin.SetStoreCurrentLanguage", CommandType.StoredProcedure, parameters).ToInteger() > 0;
            ICommonService _commonService = new CommonService();
            return _commonService.SetStoreCurrentLanguage(languageId, Convert.ToInt32(SessionHelper.CurrentSession.StoreId));
            //return true;
        }

    }
}
