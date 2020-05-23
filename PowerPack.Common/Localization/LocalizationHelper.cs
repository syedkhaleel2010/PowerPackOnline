using System.Collections.Generic;
using System.Linq;
using System;
using PowerPack.Common.ViewModels;
using PowerPack.Common.Helpers;

namespace PowerPack.Common.Localization
{
    public static class LocalizationHelper
    {
        #region Properties
        private static SystemLanguage _currentSystemLanguage;

        public static short CurrentSystemLanguageId
        {
            get
            {
                return CurrentSystemLanguage.SystemLanguageId;
            }
        }

        public static SystemLanguage CurrentSystemLanguage
        {
            get
            {
                if (_currentSystemLanguage == null)
                    _currentSystemLanguage = SystemLanguageHelper.GetSchoolCurrentLanguage();
                return _currentSystemLanguage;
            }
            set
            {
                _currentSystemLanguage = value;
            }
        }

        public static IEnumerable<SystemLanguage> SystemLanguages
        {
            get
            {
                return SystemLanguageHelper.SystemLanguages;
            }
        }

        public static string ValidationFailedMessage
        {
            get
            {
                return GetResourceText("Shared.Messages.ValidationFailed");
            }
        }

        public static string DeleteErrorDependentRecordsMessage
        {
            get
            {
                return GetResourceText("Shared.Messages.DeleteError_DependentRecords");
            }
        }
        public static string UpdateErrorDuplicateRecordMessage
        {
            get
            {
                return GetResourceText("Shared.Messages.UpdateError_DuplicateRecord");
            }
        }

        public static string TechnicalErrorMessage
        {
            get
            {
                return GetResourceText("Shared.Messages.TechnicalError");
            }
        }
        public static string NoDataToSave
        {
            get
            {
                return GetResourceText("Shared.Messages.NoDataToSave");
            }
        }
        public static string SelectAppropriateAction
        {
            get
            {
                return GetResourceText("Shared.Messages.SelectAppropriateAction");
            }
        }
        public static string DuplicateFolderName
        {
            get
            {
                return GetResourceText("Shared.Messages.DuplicateFolderName");
            }
        }

        public static string ItemExistsMessage
        {
            get
            {
                return GetResourceText("Shared.Messages.ItemExistsMessage");
            }
        }

        public static string AddSuccessMessage
        {
            get
            {
                return GetResourceText("Shared.Messages.Added");
            }
        }

        public static string UpdateSuccessMessage
        {
            get
            {
                return GetResourceText("Shared.Messages.Updated");
            }
        }

        public static string ActionNotPermittedMessage
        {
            get
            {
                return GetResourceText("Shared.Messages.ActionNotPermittedMessage");
            }
        }
        public static string ElementDeleteFailed
        {
            get
            {
                return GetResourceText("Shared.Messages.DeleteError_MarkExists");
            }
        }

        public static string ChangePasswordFailed
        {
            get
            {
                return GetResourceText("Shared.Messages.ChangePasswordMessage");
            }
        }

        public static string FileNotFound
        {
            get
            {
                return GetResourceText("Shared.Messages.FileNotFound");
            }
        }
        #endregion

        #region Methods

        public static string GetResourceText(string keyPath)
        {
            return ResourceManager.GetString(keyPath);
        }

        public static string GetResourceTextWithDefautLangCode(string keyPath)
        {
            return ResourceManager.GetString(keyPath) + "(" + CurrentSystemLanguage.SystemLanguageCode.ToUpper() + ")";
        }

        public static string GetResourceTextWithOtherLang1Code(string keyPath)
        {
            return GetResourceTextWithOtherLangCode(keyPath, 0);
        }

        public static string GetResourceTextWithOtherLang2Code(string keyPath)
        {
            return GetResourceTextWithOtherLangCode(keyPath, 1);
        }

        private static string GetResourceTextWithOtherLangCode(string keyPath, int otherLanguagePosition)
        {

            string resouceText = ResourceManager.GetString(keyPath);

            if (SystemLanguages.Any())
            {
                SystemLanguage currentSystemLanguage = CurrentSystemLanguage;
                var otherLanguages = SystemLanguages.Where(i => !i.SystemLanguageCode.Equals(currentSystemLanguage.SystemLanguageCode, StringComparison.OrdinalIgnoreCase)).ToList();
                if (otherLanguages.Count() > otherLanguagePosition)
                {
                    resouceText += "(" + otherLanguages[otherLanguagePosition].SystemLanguageCode + ")";
                }
            }

            return resouceText;
        }

        public static IEnumerable<SystemLanguageInfo> GetEnabledLanguages()
        {
            IList<SystemLanguageInfo> languages = new List<SystemLanguageInfo>();

            SystemLanguages.ToList().ForEach(l => languages.Add(
                new SystemLanguageInfo() { SystemLanguageId = l.SystemLanguageId, SystemLanguageCode = l.SystemLanguageCode }));
            return languages;
        }
        public static string GetSqlColumnExpression(string keyPath)
        {
            return GetSqlColumnExpression(keyPath, string.Empty, false);
        }

        public static string GetSqlColumnExpression(string keyPath, string columnName, bool purifyForDynamicQuery)
        {
            string result = ResourceManager.GetString(keyPath)
                                .Replace("<lang>", Convert.ToString(CurrentSystemLanguageId)) + (string.IsNullOrEmpty(columnName) ? string.Empty : " AS " + columnName);

            if (purifyForDynamicQuery)
            {
                result = result.Replace("'", "\"");
            }
            return result;
        }

        public static void UpdateCurrentSystemLanguage(int languageId)
        {
            SystemLanguageHelper.SetSchoolCurrentLanguage(languageId);
            _currentSystemLanguage = SystemLanguages.FirstOrDefault(x => x.SystemLanguageId == languageId);
        }
        #endregion

        #region Incident Management

        public static string NoIncidentAvailable
        {
            get
            {
                return GetResourceText("IncidentManagement.Mesages.NoIncidentAvailable");
            }
        }
        public static string IncidentClosed
        {
            get
            {
                return GetResourceText("IncidentManagement.Mesages.IncidentClosed");
            }
        }

        public static string RequiredInvestigationInIncident
        {
            get
            {
                return GetResourceText("IncidentManagement.Mesages.RequiredInvestigationInIncident");
            }
        }

        public static string TaskNotLogged
        {
            get
            {
                return GetResourceText("IncidentManagement.Mesages.TaskNotLogged");
            }
        }
        #endregion
    }
}
