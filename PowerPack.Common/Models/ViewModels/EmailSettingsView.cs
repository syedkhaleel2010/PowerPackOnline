using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.ViewModels
{
    public class EmailSettingsView
    {
        public string EmailCode { get; set; }
        public string AuthorizedName { get; set; }

        public string SenderEmail { get; set; }

        public string SenderPassword { get; set; }

        public string SenderName { get; set; }

        public DateTime? Date { get; set; }
        public bool IncludeTerms { get; set; }
        public string AcceptanceLetter { get; set; }
        public string AcceptanceTerms { get; set; }
        public string EmailText { get; set; }

        public string SMTPClient { get; set; }

        public string PortNo { get; set; }

        public bool IsSSLEnabled { get; set; }
    }
    public class SendEmailNotificationView
    {
        [JsonProperty("LOG_TYPE")]
        public string LogType { get; set; }
        [JsonProperty("STU_ID")]
        public string StudentId { get; set; }
        [JsonProperty("FROM_EMAIL")]
        public string FromMail { get; set; }
        [JsonProperty("SUBJECT")]
        public string Subject { get; set; }
        [JsonProperty("MSG")]
        public string Message { get; set; }
        [JsonProperty("LOG_USERNAME")]
        public string Username { get; set; }
    }
    public class SendMailView
    {
        public string LOG_TYPE { get; set; }
        public string STU_ID { get; set; }
        public string FROM_EMAIL { get; set; }
        public string TO_EMAIL { get; set; }
        public string SUBJECT { get; set; }
        public string MSG { get; set; }
        public string EmailHostNew { get; set; }
        public string LOG_USERNAME { get; set; }
        public string LOG_PASSWORD { get; set; }
        public string PORT_NUM { get; set; }
    }
    public class HSESendMailView : EmailAPIResponse
    {
        public string EmailType { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string ToEmail { get; set; }
        public string CCEmail { get; set; }
    }
    public class EmailAPIResponse
    {
        public bool IsTokenCreated { get; set; }
        public bool APIResponse { get; set; }
        public string ResponseMessage { get; set; }

    }
}
