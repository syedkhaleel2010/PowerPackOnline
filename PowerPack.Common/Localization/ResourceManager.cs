using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using PowerPack.Common.Helpers;
using PowerPack.Common.Helpers.Extensions;
using Newtonsoft.Json;
using System.Web;

namespace PowerPack.Common.Localization
{
    /// <summary>
    ///     ResourceManager class used to access localized content in XML files
    /// </summary>
    public sealed class ResourceManager
    {
        private ResourceManager() { }

        /// <summary>
        ///     Retrieves the RFC 1766 name of the current culture
        /// </summary>
        /// <remarks>
        ///     This would more likely belong in an utility/global class, but for simplicities sake, I've put it here
        /// </remarks>
        public static string CurrentCultureName
        {
            get { return System.Threading.Thread.CurrentThread.CurrentCulture.Name; }
        }

        /// <summary>
        ///     Wrapper to GetString() to get a colon
        /// </summary>
        public static string Colon
        {
            get { return GetString("colon"); }
        }

        /// <summary>
        ///     Returns 
        /// </summary>
        /// <param name="keyPath" type="string">The name of the resource we want</param>
        /// </param>
        /// <remarks>
        ///   When in DEBUG mode, an ApplicationException will be thrown if the key isn't found
        /// </remarks>
        public static string GetString(string keyPath)
        {
            return GetResourceString(keyPath, LocalizationHelper.CurrentSystemLanguage.SystemLanguageCode).ResourceValue;
        }

        /// <summary>
        ///     Returns 
        /// </summary>
        /// <param name="keyPath" type="string">The name of the resource we want</param>
        /// </param>
        /// <remarks>
        ///   When in DEBUG mode, an ApplicationException will be thrown if the key isn't found
        /// </remarks>
        public static string GetValidators(string keyPath)
        {
            return GetResourceString(keyPath, LocalizationHelper.CurrentSystemLanguage.SystemLanguageCode).Validators;
        }

        public static string GetMaxLength(string keyPath)
        {
            return GetResourceString(keyPath, LocalizationHelper.CurrentSystemLanguage.SystemLanguageCode).MaxLength;
        }

        public static IEnumerable<ResourceNode> GetDataColumns(string keyPath)
        {
            var messages = GetResource(keyPath, LocalizationHelper.CurrentSystemLanguage.SystemLanguageCode);
            IList<ResourceNode> result = new List<ResourceNode>();
            foreach (ResourceNode node in messages.Values)
            {
                if (node.IsLoadData)
                {
                    result.Add(new ResourceNode()
                    {
                        NodeName = node.NodeName,
                        ResourceValue = node.ResourceValue,
                        LanguageId = node.LanguageId,
                        IsLoadData = true,
                        IsGridVisible = node.IsGridVisible,
                        ColumnWidth = node.ColumnWidth
                    });
                }
            }
            return result;
        }

        public static bool GetVisibleInAuditLog(string keyPath)
        {
            return GetResourceString(keyPath, LocalizationHelper.CurrentSystemLanguage.SystemLanguageCode).VisibleInAuditLog;
        }

        public static string GetLogDisplayName(string keyPath, bool findInChildNodes = true)
        {
            return GetResourceString(keyPath, LocalizationHelper.CurrentSystemLanguage.SystemLanguageCode, findInChildNodes).LogDisplayName;
        }

        /// <summary>
        ///     Returns 
        /// </summary>
        /// <param name="key" type="string">The name of the resource we want</param>
        /// <param name="attribute">Which attribute of the resource node?</param>
        /// </param>
        /// <remarks>
        ///   When in DEBUG mode, an ApplicationException will be thrown if the key isn't found
        /// </remarks>
        private static ResourceNode GetResourceString(string keyPath, string languageCode, bool findInChildNodes = true)
        {
            string[] keyPathArray = keyPath.Split('.');
            if ((findInChildNodes && keyPathArray.Length < 3) || keyPathArray.Length < 2)
            {
                throw new ArgumentException("Invalid resource path!");
            }
            if (string.IsNullOrWhiteSpace(keyPathArray[0]))
            {
                throw new ArgumentException("Invalid resource file!");
            }
            if (string.IsNullOrWhiteSpace(keyPathArray[1]))
            {
                throw new ArgumentException("No such node exists!");
            }
            if (findInChildNodes && string.IsNullOrWhiteSpace(keyPathArray[2]))
            {
                throw new ArgumentException("Invalid resource key!");
            }

            string resourceFileName = keyPathArray[0];
            string parentNodeName = keyPathArray[1];
            string key = findInChildNodes== true ? keyPathArray[2] : parentNodeName;

            var messages = GetResource(languageCode, resourceFileName, parentNodeName, findInChildNodes);
            if (messages[key] == null)
            {
                throw new ApplicationException("Resource value not found for key: " + key);
            }
            return messages[key] as ResourceNode;
        }

        private static Dictionary<string, ResourceNode> GetResource(string keyPath, string languageCode, bool findInChildNodes = true)
        {
            string[] keyPathArray = keyPath.Split('.');
            if (keyPathArray.Length < 2)
            {
                throw new ArgumentException("Invalid resource path!");
            }
            if (string.IsNullOrWhiteSpace(keyPathArray[0]))
            {
                throw new ArgumentException("Invalid resource file!");
            }
            if (string.IsNullOrWhiteSpace(keyPathArray[1]))
            {
                throw new ArgumentException("No such node exists!");
            }

            string resourceFileName = keyPathArray[0];
            string parentNodeName = keyPathArray[1];
            var messages = GetResource(languageCode, resourceFileName, parentNodeName, findInChildNodes);

            if (messages.Count == 0)
            {
                throw new ApplicationException("Resource value not found for keyPath: " + keyPath);
            }

            return messages;
        }

        private static Dictionary<string, ResourceNode> GetResource(string languageCode, string resourceFileName, string parentNodeName, bool findInChildNodes)
        {
            string defaultCulture = PowerPackConfiguration.Instance.Localization.DefaultCultureName;

            if (!string.Equals(languageCode, "settings", StringComparison.OrdinalIgnoreCase))
            {
                if (!SystemLanguageHelper.SystemLanguages.Any(l => l.SystemLanguageCode.Equals(languageCode, StringComparison.OrdinalIgnoreCase)))
                {
                    languageCode = defaultCulture.Substring(0, 2);
                }
            }

            // Caching commented temporarily, enable it if it is actually required?
            //string cacheKey = "Localization:" + languageCode + ':' + resourceFileName + ':' + parentNodeName;
            //return CacheManager.GetOrStore(cacheKey, () => LoadResource(languageCode), PowerPackConfiguration.Instance.CacheDuration.ResourceXml);
            return LoadResource(languageCode, resourceFileName, parentNodeName, findInChildNodes);
        }

        private static Dictionary<string, ResourceNode> LoadResource(string languageCode, string resourceFileName, string parentNodeName, bool findInChildNodes)
        {
            string file = HttpContext.Current.Server.MapPath(PowerPackConfiguration.Instance.Localization.LanguageFilePath + "\\" + languageCode + "\\" + resourceFileName + ".xml");
            XmlDocument xml = new XmlDocument();
            xml.Load(file);
            var resource = new Dictionary<string, ResourceNode>();

            string rootNodeName = PowerPackConfiguration.Instance.Localization.RootNodeName;

            foreach (XmlNode node in xml.SelectNodes(rootNodeName)) //Root
            {
                if (findInChildNodes)
                {
                    foreach (XmlNode innerNode in node.SelectSingleNode(parentNodeName)) //Resource
                    {

                        if (innerNode.NodeType != XmlNodeType.Comment)
                        {
                            var resourceNode = new ResourceNode
                            {
                                NodeName = innerNode.Attributes["name"] != null ? innerNode.Attributes["name"].Value : string.Empty,
                                ResourceValue = innerNode.InnerText,
                                LanguageId = innerNode.Attributes["langId"] != null ? innerNode.Attributes["langId"].Value : string.Empty,
                                IsLoadData = innerNode.Attributes["loadData"] != null ? innerNode.Attributes["loadData"].Value.ToBoolean() : false,
                                IsGridVisible = innerNode.Attributes["gridVisible"] != null ? innerNode.Attributes["gridVisible"].Value.ToBoolean() : false,
                                Validators = innerNode.Attributes["validators"] != null ? innerNode.Attributes["validators"].Value : string.Empty,
                                ColumnWidth = innerNode.Attributes["colWidth"] != null ? innerNode.Attributes["colWidth"].Value : string.Empty,
                                MaxLength = innerNode.Attributes["maxLength"] != null ? innerNode.Attributes["maxLength"].Value : string.Empty,
                                VisibleInAuditLog = innerNode.Attributes["visibleinauditlog"] != null ? innerNode.Attributes["visibleinauditlog"].Value.ToBoolean() : false,
                                LogDisplayName = innerNode.Attributes["logdisplayname"] != null ? innerNode.Attributes["logdisplayname"].Value : string.Empty,
                            };

                            resource[innerNode.Attributes["name"].Value] = resourceNode;
                        }
                    }
                }
                else
                {
                    XmlNode parentNode = node.SelectSingleNode(parentNodeName);
                    if (parentNode.NodeType != XmlNodeType.Comment)
                    {
                        var resourceNode = new ResourceNode
                        {
                            NodeName = parentNode.Name,
                            ResourceValue = parentNode.InnerText,
                            LogDisplayName = parentNode.Attributes["logdisplayname"] != null ? parentNode.Attributes["logdisplayname"].Value : parentNodeName,
                        };

                        resource[parentNodeName] = resourceNode;
                    }
                }

            }
            return resource;
        }

        public static string GetSENString(string keyPath)
        {
            return GetStringFormatted(keyPath, new string[] { GetString("Shared.Labels.SEN") });
        }

        public static string GetStringFormatted(string keyPath, object[] values)
        {
            return string.Format(GetString(keyPath), values);
        }
    }


    public class ResourceNode
    {
        public string NodeName
        {
            get; set;
        }

        public string ResourceValue
        {
            get; set;
        }

        public string LanguageId
        {
            get; set;
        }

        public bool IsLoadData
        {
            get; set;
        }

        public bool IsGridVisible
        {
            get; set;
        }

        public string Validators
        {
            get; set;
        }

        public string ColumnWidth
        {
            get; set;
        }

        public string MaxLength
        {
            get; set;
        }

        public bool VisibleInAuditLog
        {
            get; set;
        }

        public string LogDisplayName
        {
            get; set;
        }
    }

    public class SettingsNode
    {
        public string Key
        {
            get; set;
        }

        public string Value
        {
            get; set;
        }
    }
}
