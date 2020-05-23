namespace PowerPack.Common.Localization
{
    public class SystemLanguageInfo
    {
        public short SystemLanguageId { get;set; }
        public string SystemLanguageCode { get;set; }

        public SystemLanguageInfo() { }

        public SystemLanguageInfo(short newLanguageId, string newLanguageCode)
        {
            SystemLanguageId = newLanguageId;
            SystemLanguageCode = newLanguageCode;
        }
    }
}
