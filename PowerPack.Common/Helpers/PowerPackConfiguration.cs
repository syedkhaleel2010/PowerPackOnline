using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Linq;

namespace PowerPack.Common.Helpers
{
    /// <summary>
    ///     Strongly-typed configuration settings
    /// </summary>
    /// <remarks>
    ///     Loads the Localization section of the configuration file (web.config), 
    ///     and makes the settings globally accessible.
    /// </remarks>
    public class PowerPackConfiguration : ConfigurationSection
    {
        private static PowerPackConfiguration _instance = null;
        #region Properties
         
        [ConfigurationProperty("DefaultLogger")]
        public string DefaultLogger
        {
            get { return Convert.ToString(base["DefaultLogger"]); }
            set { base["DefaultLogger"] = value; }
        }

        [ConfigurationProperty("localization", IsRequired = true)]
        public LocalizationElement Localization
        {
            get { return (LocalizationElement)base["localization"]; }
            set { base["localization"] = value; }
        }

        [ConfigurationProperty("cacheduration", IsRequired = true)]
        public CacheDurationElement CacheDuration
        {
            get { return (CacheDurationElement)base["cacheduration"]; }
            set { base["cacheduration"] = value; }
        }

        [ConfigurationProperty("LoginPageUrl", IsRequired = true)]
        public string LoginPageUrl
        {
            get { return Convert.ToString(base["LoginPageUrl"]); }
            set { base["LoginPageUrl"] = value; }
        }

        [ConfigurationProperty("HomePageUrl", IsRequired = true)]
        public string HomePageUrl
        {
            get { return Convert.ToString(base["HomePageUrl"]); }
            set { base["HomePageUrl"] = value; }
        }

        [ConfigurationProperty("NoPermissionPageUrl", IsRequired = true)]
        public string NoPermissionPageUrl
        {
            get { return Convert.ToString(base["NoPermissionPageUrl"]); }
            set { base["NoPermissionPageUrl"] = value; }
        }

        [ConfigurationProperty("HseApiUrl", IsRequired = true)]
        public string HseApiUrl
        {
            get { return Convert.ToString(base["HseApiUrl"]); }
            set { base["HseApiUrl"] = value; }
        }

        [ConfigurationProperty("PowerPackApiUrl", IsRequired = true)]
        public string PowerPackApiUrl
        {
            get { return Convert.ToString(base["PowerPackApiUrl"]); }
            set { base["PowerPackApiUrl"] = value; }
        }

       
        [ConfigurationProperty("AdminHomePageUrl", IsRequired = true)]
        public string AdminHomePageUrl
        {
            get { return Convert.ToString(base["AdminHomePageUrl"]); }
            set { base["AdminHomePageUrl"] = value; }
        }
       
        [ConfigurationProperty("VLEHomePageUrl", IsRequired = true)]
        public string VLEHomePageUrl
        {
            get { return Convert.ToString(base["VLEHomePageUrl"]); }
            set { base["VLEHomePageUrl"] = value; }
        }
        [ConfigurationProperty("PowerPackHomePageUrl", IsRequired = true)]
        public string PowerPackHomePageUrl
        {
            get { return Convert.ToString(base["PowerPackHomePageUrl"]); }
            set { base["PowerPackHomePageUrl"] = value; }
        }
       
        /// <summary>
        ///     AdminUserId
        /// </summary>
        [ConfigurationProperty("AdminUserId")]
        public int AdminUserId
        {
            get
            {
                int adminUserId = 1;
                int.TryParse(Convert.ToString(base["AdminUserId"]), out adminUserId);
                return adminUserId;
            }
            set { base["AdminUserId"] = value; }
        }
      
        [ConfigurationProperty("ReadFilePath", IsRequired = true)]
        public string ReadFilePath
        {
            get { return Convert.ToString(base["ReadFilePath"]); }
            set { base["ReadFilePath"] = value; }
        }
        [ConfigurationProperty("WriteFilePath", IsRequired = true)]
        public string WriteFilePath
        {
            get { return Convert.ToString(base["WriteFilePath"]); }
            set { base["WriteFilePath"] = value; }
        }
        [ConfigurationProperty("DeploymentFlag", IsRequired = true)]
        public bool DeploymentFlag
        {
            get { return Convert.ToBoolean(base["DeploymentFlag"]); }
            set { base["DeploymentFlag"] = value; }
        }

        #endregion


        #region Public functions
        /// <summary>
        ///   Gets a PortalConfiguration object
        /// </summary>
        /// <returns>
        ///    PortalConfiguration
        /// </returns>
        public static PowerPackConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (PowerPackConfiguration)WebConfigurationManager
                         .GetSection("PowerPack");
                }
                return _instance;
            }
        }

        #endregion
    }

    public class LocalizationElement : ConfigurationElement
    {
        #region Properties

        /// <summary>
        ///     Default culture to use
        /// </summary>
        [ConfigurationProperty("defaultCulture")]
        public string DefaultCultureName
        {
            get { return Convert.ToString(base["defaultCulture"]); }
            set { base["defaultCulture"] = value; }
        }

        /// <summary>
        ///     Full path to the language folder
        /// </summary>
        [ConfigurationProperty("languageFilePath")]
        public string LanguageFilePath
        {
            get { return Convert.ToString(base["languageFilePath"]); }
            set { base["languageFilePath"] = value; }
        }

        /// <summary>
        ///     Full path to the language folder
        /// </summary>
        [ConfigurationProperty("rootNodeName")]
        public string RootNodeName
        {
            get { return Convert.ToString(base["rootNodeName"]); }
            set { base["rootNodeName"] = value; }
        }



        #endregion
    }

    public class CacheDurationElement : ConfigurationElement
    {
        #region properties

        /// <summary>
        ///     ResourceXml
        /// </summary>
        [ConfigurationProperty("resourcexml")]
        public double ResourceXml
        {
            get
            {
                double cacheDuration = 360;
                double.TryParse(Convert.ToString(base["resourcexml"]), out cacheDuration);
                return cacheDuration;
            }
            set { base["resourcexml"] = value; }
        }

        /// <summary>
        ///     Menu
        /// </summary>
        [ConfigurationProperty("menu")]
        public double Menu
        {
            get
            {
                double cacheDuration = 360;
                double.TryParse(Convert.ToString(base["menu"]), out cacheDuration);
                return cacheDuration;
            }
            set { base["menu"] = value; }
        }

        /// <summary>
        ///     ReportCacheExpiry
        /// </summary>
        [ConfigurationProperty("ReportCacheExpiry")]
        public double ReportCacheExpiry
        {
            get
            {
                double cacheDuration = 30;
                double.TryParse(Convert.ToString(base["ReportCacheExpiry"]), out cacheDuration);
                return cacheDuration;
            }
            set { base["ReportCacheExpiry"] = value; }
        }
        #endregion
    }

}