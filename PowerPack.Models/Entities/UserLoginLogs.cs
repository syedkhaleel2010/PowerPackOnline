using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models.Entities
{
    public class UserLoginLogs
    {
        public long LoginId { get; set; }
        public string LoginUserName { get; set; }
        public bool LoginMode { get; set; }
        public string LoginSource { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogOutTime { get; set; }
        public bool LoginStatus { get; set; }
        public string LoginBrowser { get; set; }
        public string LoginIP { get; set; }
        public string LoginSessionId { get; set; }
        public string Type { get; set; } //Login or LogOut
        public bool IsPowerPackApiValid { get; set; }
        public string AuthorizationLog { get; set; }
    }
}
