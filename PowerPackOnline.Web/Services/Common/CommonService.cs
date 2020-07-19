
using PowerPack.Common.Helpers;
using PowerPack.Common.Logger;
using PowerPack.Common.ViewModels;
///using PowerPackOnline.Web.Areas.SMS.Model.Common;
using PowerPackOnline.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Script.Serialization;

namespace PowerPackOnline.Web.Services
{
    public class CommonService : ICommonService
    {
        #region private variables
        static HttpClient _client = new HttpClient();
        readonly string _baseUrl = Constants.PowerPackApiUrl;
        readonly string _path = "api/v1/Common";
        readonly string _PowerPackAPiBaseUri = ConfigurationManager.AppSettings["PowerPackAPIBaseUri"];
        readonly string SendEmailNotificationApi = ConfigurationManager.AppSettings["SendEmailNotification"];
        readonly string SendEmailApi = ConfigurationManager.AppSettings["SendEmailApi"];
        
        ApiCredentials apiCredentials;
        private ILoggerClient _loggerClient;
        public CommonService()
        {
            if (_client.BaseAddress == null)
            {
                // Initializing our HttpClient temporarly here, try to move into some generic class.
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
            apiCredentials = new ApiCredentials()
            {
                AppId = ConfigurationManager.AppSettings["AppId"],
                Password = ConfigurationManager.AppSettings["APIPassword"],
                UserName = ConfigurationManager.AppSettings["APIUsername"],
                GrantType = ConfigurationManager.AppSettings["APIGrant_type"],
                TokenApiUrl = ConfigurationManager.AppSettings["TokenAPI"]

            };
        }
        #endregion
        public EmailSettingsView GetEmailSettings()
        {
            var emailSettingsView = new EmailSettingsView();

            var uri = API.Common.GetEmailSettings(_path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                emailSettingsView = EntityMapper<string, EmailSettingsView>.MapFromJson(jsonDataProviders);
            }
            return emailSettingsView;
        }

        public SystemLanguage GetStoreCurrentLanguage(int StoreId)
        {
            var systemLanguage = new SystemLanguage();

            var uri = API.Common.GetStoreCurrentLanguage(_path, StoreId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                systemLanguage = EntityMapper<string, SystemLanguage>.MapFromJson(jsonDataProviders);
            }
            return systemLanguage;
        }

        public bool SetStoreCurrentLanguage(int languageId, int StoreId)
        {
            var result = false;
            var uri = API.Common.SetStoreCurrentLanguage(_path, languageId, StoreId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
                result = Convert.ToBoolean(jsonDataProviders);
            }
            return result;
        }

        public TokenResult GetAuthorizationTokenAsync(ApiCredentials apiCredentials)
        {
            TokenResult JsonDeserilize = new TokenResult();
            if (HttpContext.Current.Session["AccessToken"] != null)
            {
                JsonDeserilize = (TokenResult)HttpContext.Current.Session["AccessToken"];
            }
            else
            {
                string _ContentType = "application/x-www-form-urlencoded";
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("AppId", apiCredentials.AppId));
                nvc.Add(new KeyValuePair<string, string>("password", apiCredentials.Password));
                nvc.Add(new KeyValuePair<string, string>("username", apiCredentials.UserName));
                nvc.Add(new KeyValuePair<string, string>("grant_type", apiCredentials.GrantType));

                using (var test = new HttpRequestMessage(HttpMethod.Post, apiCredentials.TokenApiUrl) { Content = new FormUrlEncodedContent(nvc) })
                {
                    using (var result = _client.SendAsync(test).Result)
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var jsonDataStatus = result.Content.ReadAsStringAsync().Result;
                            try
                            {
                                JsonDeserilize = new JavaScriptSerializer().Deserialize<TokenResult>(jsonDataStatus);
                            }
                            finally
                            {
                                result.Dispose();
                            }
                        }
                    }
                }

                HttpContext.Current.Session["AccessToken"] = JsonDeserilize;
            }

            return JsonDeserilize;

        }
        public OperationDetails SendEmail(SendMailView sendMailView)
        {
            var operationDetails = new OperationDetails();
            var token = GetAuthorizationTokenAsync(apiCredentials);
            if (token != null)
            {
                if (!string.IsNullOrEmpty(token.token_type) && !string.IsNullOrEmpty(token.token_type))
                {
                    string AuthorizedToken = token.token_type + " " + token.access_token;
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(_PowerPackAPiBaseUri);
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                            client.DefaultRequestHeaders.Add("Authorization", AuthorizedToken);
                            HttpResponseMessage userResp = client.PostAsJsonAsync(SendEmailApi, sendMailView).Result;
                            operationDetails.Success = userResp.IsSuccessStatusCode;
                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerClient = LoggerClient.Instance;
                        _loggerClient.LogException(ex);
                    }
                }
            }
            return operationDetails;
        }
        public bool SendEmailNotifications(SendEmailNotificationView sendEmailNotificationView)
        {
            bool isSent = false;

            var token = GetAuthorizationTokenAsync(apiCredentials);

            if (token != null)
            {
                if (!string.IsNullOrEmpty(token.token_type) && !string.IsNullOrEmpty(token.token_type))
                {
                    string AuthorizedToken = token.token_type + " " + token.access_token;

                    try 
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(_PowerPackAPiBaseUri);
                            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", AuthorizedToken);
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                            client.DefaultRequestHeaders.Add("Authorization", AuthorizedToken);
                            HttpResponseMessage userResp = client.PostAsJsonAsync(SendEmailNotificationApi, sendEmailNotificationView).Result;
                            isSent = userResp.IsSuccessStatusCode;

                        }
                    }
                    catch (Exception ex)
                    {
                        _loggerClient = LoggerClient.Instance;
                        _loggerClient.LogException(ex);
                    }
                    
                }
            }

            return isSent;
        }

      
    }
}