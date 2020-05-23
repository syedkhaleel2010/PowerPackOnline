using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.ViewModels
{
    public class ApiCredentials
    {
        public string GrantType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AppId { get; set; }
        public string TokenApiUrl { get; set; }
    }

    public class TokenResult
    {
        public string access_token { get; set; }
        public string token_type { get; set; }

    }
}
