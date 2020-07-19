using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using PowerPack.Common.Helpers;
using PowerPack.Common.Helpers.Extensions;
using PowerPack.Models.Entities;
using PowerPackOnline.Web.Helpers;

namespace PowerPackOnline.Web.Services
{
    public class ErrorLoggerService : IErrorLoggerService
    {
        #region private variables
        static HttpClient _client = new HttpClient();
        readonly string _baseUrl = Constants.PowerPackApiUrl;
        readonly string _path = "api/v1/ErrorLogger";
        #endregion

        public ErrorLoggerService()
        {
            if (_client.BaseAddress == null)
            {
                // Initializing our HttpClient temporarly here, try to move into some generic class.
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        #region Public Methods
        public string GetErrorLog(string applicationName, Guid errorId)
        {
            var uri = API.ErrorLogger.GetErrorLog(_path, applicationName, errorId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            return string.Empty;
        }

        public ErrorLog GetErrorLogs(string applicationName, int pageIndex, int pageSize, string search, string sortColumn, string sortColumnDir)
        {
            ErrorLog errorLog = new ErrorLog();
            var uri = API.ErrorLogger.GetErrorLogs(_path, applicationName, pageIndex, pageSize, search,sortColumn, sortColumnDir);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                errorLog = EntityMapper<string, ErrorLog>.MapFromJson(jsonDataProviders);
            }
            return errorLog;
        }

        public bool LogError(Exception ex, HttpContext httpContext)
        {
            var errorLogObject = GetErrorLogModel(ex, httpContext);
            var uri = API.ErrorLogger.LogError(_path);
            HttpResponseMessage response = _client.PostAsJsonAsync(uri, errorLogObject).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result.ToBoolean();
            }
            return false;
        }
        #endregion

        #region private methods
        private ErrorLogModel GetErrorLogModel(Exception ex , HttpContext httpContext)
        {
            var error = new Elmah.Error(ex, httpContext);
            var log = Elmah.ErrorLog.GetDefault(httpContext);
            error.ApplicationName = log.ApplicationName;
            var id = log.Log(error);
            var entry = new Elmah.ErrorLogEntry(log, id, error);
            StringWriter writer = new StringWriter(new StringBuilder());
            Elmah.ErrorJson.Encode(entry.Error, writer);
            var str = writer.ToString();

            return new ErrorLogModel
            {
                AllXml = str,
                Application = entry.Error.ApplicationName,
                ErrorId = Guid.NewGuid(),
                Host = entry.Error.HostName,
                IsWeb = true,
                Message = entry.Error.Message,
                Source = entry.Error.Source,
                StatusCode = entry.Error.StatusCode,
                TimeUtc = entry.Error.Time,
                Type = entry.Error.Type,
                User = entry.Error.User,
                StoreId = SessionHelper.CurrentSession.Id
            };
        }
        #endregion
    }
}