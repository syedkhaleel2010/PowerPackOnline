using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PowerPackOnline.Web.ViewModels
{

    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        //public bool RememberMe { get; set; }
    }
    public class LoginUser
    {
        public string Cmd { get; set; }
        public string SuccessMessage { get; set; }
        public string success { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public List<LoginViewModel> data { get; set; }
    }
}