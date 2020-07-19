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
            public static string GetCurrentLanguage(string baseUri, int Id) => $"{baseUri}/getCurrentLanguage?Id={Id}";
            public static string SetCurrentLanguage(string baseUri, int languageId, int Id) => $"{baseUri}/setCurrentLanguage?languageId={languageId}&Id={Id}";

        }
    }
}
