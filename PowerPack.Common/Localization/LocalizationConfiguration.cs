using System.Configuration;
using System.Xml;

namespace PowerPack.Common.Localization
{
    /// <summary>
    ///     Strongly-typed configuration settings
    /// </summary>
    /// <remarks>
    ///     Loads the Localization section of the configuration file (web.config), 
    ///     and makes the settings globally accessible.
    /// </remarks>
    public class LocalizationConfiguration
    {
        #region fields and properties
        private string defaultCultureName;
        private string languageFilePath;
        private string enabledLanguages;
        private string rootNodeName;

        /// <summary>
        ///     Enabled languages
        /// </summary>
        public string EnabledLanguages
        {
            get { return enabledLanguages; }
            set { enabledLanguages = value; }
        }

        /// <summary>
        ///     Default culture to use
        /// </summary>
        public string DefaultCultureName
        {
            get { return defaultCultureName; }
            set { defaultCultureName = value; }
        }

        /// <summary>
        ///     Full path to the language folder
        /// </summary>
        public string LanguageFilePath
        {
            get { return languageFilePath; }
            set { languageFilePath = value; }
        }

        /// <summary>
        ///     Full path to the language folder
        /// </summary>
        public string RootNodeName
        {
            get { return rootNodeName; }
            set { rootNodeName = value; }
        }
        #endregion


        #region Public functions
        /// <summary>
        ///   Gets a PortalConfiguration object
        /// </summary>
        /// <returns>
        ///    PortalConfiguration
        /// </returns>
        public static LocalizationConfiguration GetConfig()
        {
            
            return (LocalizationConfiguration)System.Configuration.ConfigurationManager.GetSection("Localization/Localization");
        }
        #endregion


        internal void LoadConfigValues(XmlNode node)
        {
            XmlAttributeCollection attributeCollection = node.Attributes;
            defaultCultureName = attributeCollection["defaultCulture"].Value;
            languageFilePath = attributeCollection["languageFilePath"].Value;
            enabledLanguages = attributeCollection["enabledLanguages"].Value;
            rootNodeName = attributeCollection["rootNodeName"].Value;
        }
    }

    public class LocalizationConfigurationHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object context, XmlNode node)
        {
            LocalizationConfiguration config = new LocalizationConfiguration();
            config.LoadConfigValues(node);
            return config;
        }
    }
}