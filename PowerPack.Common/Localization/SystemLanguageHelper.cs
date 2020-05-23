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
        public static SystemLanguage GetSchoolCurrentLanguage()
        {
            //DataHelper _datahelper = new DataHelper();
            //DataParameter parameter = new DataParameter("@SchoolId", SqlDbType.BigInt, PowerPackConfiguration.Instance.DefaultSchoolId);
            //string query = "SELECT TOP 1 SystemLanguageId FROM Admin.SchoolSettings WHERE SchoolId = @SchoolId";
            //int currentLanguageId = _datahelper.GetScalarValue(query, CommandType.Text, parameter).ToInteger();
            //if(currentLanguageId > 0)
            //    return SystemLanguages.FirstOrDefault(x => x.SystemLanguageId == currentLanguageId);
            //else
            ICommonService _commonService = new CommonService();
            int currentLanguageId = _commonService.GetSchoolCurrentLanguage(Convert.ToInt32(SessionHelper.CurrentSession.SchoolId)).SystemLanguageId;
            if (currentLanguageId > 0)
                return SystemLanguages.FirstOrDefault(x => x.SystemLanguageId == currentLanguageId);
            else
                return new SystemLanguage(1, "EN");
        }

        public static bool SetSchoolCurrentLanguage(int languageId)
        {
            //DataHelper _datahelper = new DataHelper();
            //IList<DataParameter> parameters = new List<DataParameter>();
            //parameters.Add(new DataParameter("@SchoolId", SqlDbType.BigInt, PowerPackConfiguration.Instance.DefaultSchoolId));
            //parameters.Add(new DataParameter("@SystemLanguageId", SqlDbType.Int, languageId));
            //return _datahelper.ExecuteNonQuery("Admin.SetSchoolCurrentLanguage", CommandType.StoredProcedure, parameters).ToInteger() > 0;
            ICommonService _commonService = new CommonService();
            return _commonService.SetSchoolCurrentLanguage(languageId, Convert.ToInt32(SessionHelper.CurrentSession.SchoolId));
            //return true;
        }

    }
}
