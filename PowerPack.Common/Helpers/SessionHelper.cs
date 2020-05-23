using PowerPack.Common.Extensions;
using PowerPack.Common.ViewModels;
using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;

namespace PowerPack.Common.Helpers
{
    public static class SessionHelper
    {
        public static UserPrincipal CurrentSession
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var userData = HttpContext.Current.User as UserPrincipal;
                    if (HttpContext.Current.Session["Token"] != null)
                    {
                        userData.Token = HttpContext.Current.Session["Token"].ToString();
                    }
                    return (userData);
                }
                return new UserPrincipal();
            }
        }
        public static void RemoveKeepAliveCookie()
        {
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(cookie1);

            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(cookie2);

            string[] myCookies = HttpContext.Current.Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                HttpContext.Current.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
        }
        public static void LogOffUser()
        {
            RemoveKeepAliveCookie();
            if (HttpContext.Current.Session != null)
            { HttpContext.Current.Session.Clear(); }
            FormsAuthentication.SignOut();
            HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
        }
        public static bool IsSessionActive()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static void RedirectToLoginPage()
        {
            HttpContext.Current.Response.Redirect(PowerPackConfiguration.Instance.LoginPageUrl);
        }
    }
}