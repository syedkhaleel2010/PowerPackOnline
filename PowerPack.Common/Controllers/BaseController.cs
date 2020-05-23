using PowerPack.Common.Helpers;
using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerPack.Common
{
    public class BaseController : Controller
    {
        public static PagePermission InnerPagePermission;

        public static PagePermission CurrentPagePermission
        {
            get
            {
                return (PagePermission)System.Web.HttpContext.Current.Session[CommonHelper.GetPermissionKey()];
            }
            set
            {
                System.Web.HttpContext.Current.Session[CommonHelper.GetPermissionKey()] = value;
            }
        }

        public ActionResult LogOffUser()
        {
            return Redirect("/Account/SignOut");
        }
    }
}