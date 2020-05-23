using System;
using System.Configuration;
using PowerPack.Common.Localization;
using System.Collections.Generic;
using PowerPack.Common.Helpers.Extensions;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using System.Reflection;
using System.Xml;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace PowerPack.Common.Helpers
{
    public static class CommonHelper
    {


        #region Password


        private readonly static Random _rand = new Random();

        public static string GenerateStrongRandomPassword(int length = 6, int alpha = 3, int numeric = 2, int spc = 1)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string number = "1234567890";
            const string special = "!@#$%^&*_-=+";
            var pass = "";

            for (var i = 0; i < alpha; i++)
            {
                pass += chars[_rand.Next(0, chars.Length)];
            }

            for (var i = 0; i < numeric; i++)
            {
                pass += number[_rand.Next(0, number.Length)];
            }

            for (var i = 0; i < spc; i++)
            {
                pass += special[_rand.Next(0, special.Length)];
            }
            pass = new string(pass.ToCharArray().OrderBy(s => (_rand.Next(2) % 2) == 0).ToArray());
            return pass.ToString();
        }


        public static string GenerateRandomPassword()
        {
            return GenerateRandomString(7);
        }

        public static string GenerateRandomString(int maxLength)
        {
            string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            Random randNum = new Random();
            char[] chars = new char[maxLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < maxLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }

            return new string(chars);
        }

        #endregion

        #region General


        /// <summary>
        /// GetQueryStringValueString Method - Returns QueryString value. 
        /// </summary>
        /// <param name="queryStringName">Name of the QueryString</param>
        /// <returns>Returns QueryString value</returns>
        public static string GetQueryStringValueString(string queryStringName)
        {
            string result = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.Request.QueryString[queryStringName] != null)
                result = Convert.ToString(HttpContext.Current.Request.QueryString[queryStringName]);
            return result;
        }

        public static bool CompareUrls(string source, string destination)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(destination))
            {
                return false;
            }
            source = source.Replace("\\", "/");
            destination = destination.Replace("\\", "/");
            return source.Equals(destination, StringComparison.OrdinalIgnoreCase);
        }



        public static string CreateDestinationFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public static string CheckIfFileExistsAndReturnFullPath(string parentFolder, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;
            bool isFileExists = File.Exists(Path.Combine(PowerPackConfiguration.Instance.ReadFilePath, parentFolder, fileName));
            return isFileExists ? Path.Combine(PowerPackConfiguration.Instance.WriteFilePath, parentFolder, fileName) : string.Empty;
        }
        public static DateTime GetMonthStartDate(int year, int month)
        {
            return new DateTime(year, month, 1);
        }

        public static DateTime GetMonthEndDate(int year, int month)
        {
            var firstDayOfMonth = new DateTime(year, month, 1);
            return firstDayOfMonth.AddMonths(1).AddDays(-1);
        }

        public static string TimeAgo(this DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} Seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("{0} Minutes ago", timeSpan.Minutes) :
                    "A minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("{0} Hours ago", timeSpan.Hours) :
                    "An hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("{0} Days ago", timeSpan.Days) :
                    "Yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("{0} Months ago", timeSpan.Days / 30) :
                    "A month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("{0} Years ago", timeSpan.Days / 365) :
                    "A year ago";
            }

            return result;
        }


        #region GetPermissionKey (2 overloads)

        public static string GetPermissionKey()
        {
            return GetControllerUrl().Replace("\\", "_").Replace("/", "_");
        }

        public static string GetControllerActionUrl()
        {
            object areaName;
            var routeData = System.Web.Routing.RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current));
            routeData.DataTokens.TryGetValue("area", out areaName);

            var values = routeData.Values;
            var controllerName = values["controller"];
            var actionName = values["action"];

            string url = areaName != null ? "/" : "";
            url += areaName + "/" + controllerName + "/" + actionName;
            return url.ToLower();
        }

        public static string GetControllerUrl()
        {
            object areaName;
            var routeData = System.Web.Routing.RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current));
            routeData.DataTokens.TryGetValue("area", out areaName);

            var values = routeData.Values;
            var controllerName = values["controller"];

            string url = areaName != null ? "/" : "";
            url += areaName + "/" + controllerName;
            return url;
        }


        #endregion
        #endregion


        #region CSV

        public static string SaveCSVFile(HttpPostedFileBase file, string folderPath)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName);

                bool exists = System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(folderPath));
                bool existsFile = System.IO.File.Exists(HttpContext.Current.Server.MapPath(folderPath + fileName));

                if (!exists)
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(folderPath));
                if (existsFile)
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(folderPath + fileName));

                var path = Path.Combine(HttpContext.Current.Server.MapPath(folderPath), fileName);
                file.SaveAs(path);

                return "/" + folderPath.Substring(1) + "/" + fileName;
            }
            return null;
        }

        public static void ExportCSVFile(DataTable dt, string folderPath, string fileName)
        {
            // Create the CSV file to which grid data will be exported.
            Random random = new Random();
            int num = random.Next();
            fileName = fileName + num.ToString() + ".csv";
            string fullFileName = string.Concat(folderPath, fileName);

            StreamWriter sw = new StreamWriter(fullFileName, false);
            // First we will write the headers.
            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);

            // Now write all the rows.
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "inline; filename=" + fileName);
            HttpContext.Current.Response.TransmitFile(fullFileName);
            HttpContext.Current.Response.End();
        }

        #endregion
        #region Document upload path


        public static string TruncateLeftSlashFromPath(string path)
        {
            string[] pathString = path.Split('\\');
            path = path.Replace("\\", "/");

            if (path.StartsWith("/"))
            {
                path = path.Substring(1, path.Length - 1);
            }
            return path;
        }


        #endregion

        #region File Operations 
        public static void SaveFiles(List<HttpPostedFileBase> files, string folderPath, bool isRandomFile)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    SaveFile(file, folderPath, isRandomFile);
                }
            }
        }

        public static string SaveFile(HttpPostedFileBase file, string folderPath, bool isRandomFile)
        {
            return SaveFile(file, folderPath, isRandomFile, string.Empty);
        }

        public static string SaveFile(HttpPostedFileBase file, string folderPath, bool isRandomFile, string staticFileName)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fileNameBackup = !string.IsNullOrEmpty(staticFileName) ? staticFileName : file.FileName;
                string fileName = Path.GetFileNameWithoutExtension(fileNameBackup);
                if (isRandomFile)
                {
                    fileName += "_" + Guid.NewGuid();
                }
                fileName += Path.GetExtension(fileNameBackup);
                if (folderPath.StartsWith("\\") || folderPath.StartsWith("/"))
                {
                    folderPath = folderPath.Substring(1);
                }
                string fullFolderPath = Path.Combine(PowerPackConfiguration.Instance.WriteFilePath, folderPath);
                string fullFilePath = Path.Combine(fullFolderPath, fileName);

                if (!Directory.Exists(fullFolderPath))
                    Directory.CreateDirectory(fullFolderPath);
                if (File.Exists(fullFilePath))
                    File.Delete(fullFilePath);

                file.SaveAs(fullFilePath);

                return folderPath + "/" + fileName;
            }
            return null;
        }

        public static bool DeleteFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
            }
            return false;
        }

        public static void DeleteEntireFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                if (Directory.EnumerateFiles(folderPath).Any())
                { Array.ForEach(Directory.GetFiles(folderPath), System.IO.File.Delete); }
                System.IO.Directory.Delete(folderPath);
            }
        }

        public static bool CheckImageExtension(string filename)
        {
            bool bFlag = false;
            if (filename.ToLower().Contains("jpg") || filename.ToLower().Contains("jpeg") || filename.ToLower().Contains("png") || filename.ToLower().Contains("bmp") || filename.ToLower().Contains("gif"))
            { bFlag = true; }
            return bFlag;
        }
        public static bool CheckVideoExtension(string filename)
        {
            bool bFlag = false;
            if (filename.ToLower().Contains("mp4") || filename.ToLower().Contains("3gp") || filename.ToLower().Contains("flv") || filename.ToLower().Contains("avi") || filename.ToLower().Contains("mov") || filename.ToLower().Contains("mkv"))
            { bFlag = true; }
            return bFlag;
        }
        public static bool CheckFileExtension(string filename)
        {
            bool bFlag = false;
            if (filename.ToLower().Contains("csv") || filename.ToLower().Contains("docx") || filename.ToLower().Contains("doc") || filename.ToLower().Contains("xlsx") || filename.ToLower().Contains("xls") || filename.ToLower().Contains("pdf") || filename.ToLower().Contains("ppt"))
            { bFlag = true; }
            return bFlag;
        }

        #endregion

        public static string ParseXmlToJson(string xmlString)
        {
            XElement rootElement = XElement.Parse(xmlString);
            string jsonData = "{";
            if (rootElement.Elements().Count() > 0)
            {
                foreach (XElement node in rootElement.Elements())
                {
                    if (node.Value.IsNumeric(System.Globalization.NumberStyles.AllowDecimalPoint) || node.Value.IsBoolean())
                        jsonData += string.Format("\"{0}\":{1},", node.Attribute("name").Value, node.Value);
                    else
                        jsonData += string.Format("\"{0}\":\"{1}\",", node.Attribute("name").Value, node.Value);
                }
                jsonData = jsonData.TrimEnd(',');
            }
            jsonData += "}";
            return jsonData;
        }

        public static string ParseLanguageXmlToJson(string xmlString)
        {
            XElement rootElement = XElement.Parse(xmlString);
            string jsonData = "{";
            if (rootElement.Elements().Count() > 0)
            {
                foreach (XElement node in rootElement.Elements())
                {
                    jsonData += string.Format("\"Language_{0}\":\"{1}\",", node.Attribute("lang").Value, node.Value);
                }
                jsonData = jsonData.TrimEnd(',');
            }
            jsonData += "}";
            return jsonData;
        }

        public static T MapLanguageFieldToModel<T>(string xmlString)
        {
            var jsonString = ParseLanguageXmlToJson(xmlString);
            if (string.IsNullOrEmpty(jsonString))
            {
                return Activator.CreateInstance<T>();
            }
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static void ProcessLanguageProperties<T>(this object source, T model)
        {
            PropertyInfo[] sourceProperties = source.GetType().GetProperties();
            foreach (var language in SystemLanguageHelper.SystemLanguages)
            {
                var propertyName = "Language_" + language.SystemLanguageId;
                source.GetType().GetProperty(propertyName).SetValue(source, model.GetType().GetProperty(propertyName).GetValue(model));
            }

        }

        public static string GetXmlAttributeValue(string attribute, string xmlString)
        {
            if (string.IsNullOrEmpty(xmlString))
                return string.Empty;

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString);
            var resource = string.Empty;

            string rootNodeName = PowerPackConfiguration.Instance.Localization.RootNodeName;

            foreach (XmlNode node in xml.SelectNodes(rootNodeName)) //Root
            {
                foreach (XmlNode innerNode in node.ChildNodes) //Resource
                {
                    if (innerNode.NodeType != XmlNodeType.Comment)
                    {
                        if (innerNode.Attributes["name"].Value == attribute)
                        {
                            resource = innerNode.InnerText;
                            break;
                        }
                    }
                }
            }
            return resource;
        }

        public static void ParseJsonToXml(this object source, string xmlFieldName)
        {
            var propertyName = xmlFieldName + "Xml";
            var jsonString = Convert.ToString(source.GetType().GetProperty(propertyName).GetValue(source));
            if (!string.IsNullOrEmpty(jsonString))
            {
                XmlDocument doc = JsonConvert.DeserializeXmlNode("{\"Item\":" + WebUtility.UrlDecode(jsonString.ToString()) + "}", "Root");
                source.GetType().GetProperty(xmlFieldName).SetValue(source, doc.OuterXml);
            }
        }
        #region File Validation
        public static List<T> AddImageFiles<T>(this List<T> source)
        {
            return AddValidFiles<T>(source, "I");
        }
        public static List<T> AddVideoFiles<T>(this List<T> source)
        {
            return AddValidFiles<T>(source, "V");
        }
        public static List<T> AddImageVideoFiles<T>(this List<T> source)
        {
            return AddValidFiles<T>(source, "I,V");
        }
        public static List<T> AddFiles<T>(this List<T> source)
        {
            return AddValidFiles<T>(source, "F");
        }
        public static List<T> AddNonMediaFiles<T>(this List<T> source)
        {
            return AddValidFiles<T>(source, "NM");
        }
        public static List<T> AddValidFiles<T>(this List<T> source, string format)
        {
            List<T> result = new List<T>();
            var formats = format.Split(',');
            foreach (var FileFormat in formats)
            {
                foreach (var item in source)
                {
                    Type t = item.GetType();

                    PropertyInfo prop = t.GetProperty("FileName");

                    string fileName = (string)prop.GetValue(item);

                    string fileExtension = Path.GetExtension(fileName);
                    if (FileFormat == "I")
                    {
                        if (ImageExtensions().Contains(fileExtension.ToLower()))
                        {
                            result.Add(item);
                        }
                    }
                    if (FileFormat == "V")
                    {
                        if (VideoExtensions().Contains(fileExtension.ToLower()))
                        {
                            result.Add(item);
                        }
                    }
                    if (FileFormat == "NM")
                    {
                        if (!(VideoExtensions().Contains(fileExtension.ToLower()) || ImageExtensions().Contains(fileExtension.ToLower())))
                        {
                            result.Add(item);
                        }
                    }
                    if (FileFormat == "F")
                    {
                        if (FileExtensions().Contains(fileExtension))
                        {
                            result.Add(item);
                        }
                    }
                }
            }

            return result;
        }
        public static IList<string> ImageExtensions()
        {
            IList<string> listObj = new List<string>();
            listObj.Add(".jpg");
            listObj.Add(".jpeg");
            listObj.Add(".png");
            listObj.Add(".bmp");
            listObj.Add(".png");
            listObj.Add(".gif");
            return listObj;
        }
        public static IList<string> VideoExtensions()
        {
            IList<string> listObj = new List<string>();
            listObj.Add(".mp4");
            listObj.Add(".3gp");
            listObj.Add(".flv");
            listObj.Add(".avi");
            listObj.Add(".mov");
            listObj.Add(".mkv");
            return listObj;
        }
        public static IList<string> FileExtensions()
        {
            IList<string> listObj = new List<string>();
            listObj.Add(".pdf");
            listObj.Add(".txt");
            listObj.Add(".docx");
            listObj.Add(".xlx");
            return listObj;
        }

        #endregion

        public static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
