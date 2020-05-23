using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.ViewModels
{
    public class SystemLanguage
    {
        public SystemLanguage()
        {
        }
        public SystemLanguage(short newLanguageId, string newLanguageCode)
        {
            SystemLanguageId = newLanguageId;
            SystemLanguageCode = newLanguageCode;
        }
        public short SystemLanguageId { get; set; }
        public string SystemLanguageName { get; set; }
        public string SystemLanguageCode { get; set; }
        public string CultureString { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsRightToLeft { get; set; }
        public bool IsDefault { get; set; }
    }
}
