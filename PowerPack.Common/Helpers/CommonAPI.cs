using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.Helpers
{
    public static class CommonAPI
    {
        public static class Common
        {
            public static string GetEmailSettings(string baseUri) => $"{baseUri}/getEmailSettings";
            public static string GetSchoolCurrentLanguage(string baseUri, int schoolId) => $"{baseUri}/getSchoolCurrentLanguage?schoolId={schoolId}";
            public static string SetSchoolCurrentLanguage(string baseUri, int languageId, int schoolId) => $"{baseUri}/setSchoolCurrentLanguage?languageId={languageId}&schoolId={schoolId}";

        }
    }
}
