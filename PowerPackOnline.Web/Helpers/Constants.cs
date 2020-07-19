using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PowerPack.Common.Helpers;
namespace PowerPackOnline.Web.Helpers
{
    public static class Constants
    {
        public static readonly string PowerPackAPIUrl = PowerPackConfiguration.Instance.PowerPackApiUrl;
        public static readonly string PowerPackApiUrl = PowerPackConfiguration.Instance.PowerPackApiUrl;
        public const string IdentityAPIUrl = @"http://localhost:5501";
        public const string PowerPackUrl = @"http://localhost:6864/";
        public const string RedirectUri = @"http://localhost:5550/signin-oidc";
        public const string PostLogoutRedirectUri = @"http://localhost:5550/signout-callback-oidc";
        //added to resolve error
        // public const string PowerPackApiUrl = @"";


        public const string ClientId = "PowerPackapp";
        public const string ClientSecret = "secret";
        public const string AuthorizeEndpoint = PowerPackUrl + "/connect/authorize";
        public const string LogoutEndpoint = PowerPackUrl + "/connect/endsession";
        public const string TokenEndpoint = PowerPackUrl + "/connect/token";
        public const string UserInfoEndpoint = PowerPackUrl + "/connect/userinfo";
        public const string IdentityTokenValidationEndpoint = PowerPackUrl + "/connect/identitytokenvalidation";
        public const string TokenRevocationEndpoint = PowerPackUrl + "/connect/revocation";

        //for report abuse mail template and other constant
      
        public const string ResourcesDir = "/Resources";
        public const string BlogDir = "/Resources/BlogContent";
        public const string FileDir = "/Resources/FileContent";

        //excel connection strings
        public const string Excel03ConString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties = 'Excel 8.0;HDR={1}'";
        public const string Excel07ConString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties = 'Excel 12.0;HDR={1}'";
        public const string StoreImagesPath = "/Uploads/StoreImages/";
        
        
        //Error Screen Shots
        public const string ErrorScreenShotDir = "/Resources/ErrorScreens";
        public const string ErrorScreenShots = "/Resources/ErrorScreenShots";

        public const string DateFormat = "dd-MMM-yyyy";

      
    }

}