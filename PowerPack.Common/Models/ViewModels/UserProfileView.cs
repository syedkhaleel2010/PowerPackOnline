using PowerPack.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerPack.Common.Models
{
    public class UserProfileView
    {
        public UserProfileView()
        {
            UserProfileList = new List<UserProfileView>();
            UserFeeling = new UserFeelingView();
        }
        public string LoginType { get; set; }
        public enum ModuleCode { }
        public UserFeelingView UserFeeling { get; set; }
        public int AvatarId { get; set; }
        public string Avatarname { get; set; }
        public string AvatarLogo { get; set; }
        public int UserId { get; set; }
        public string ProfilePhoto { get; set; }
        //public HttpPostedFileBase ProfilePhoto { get; set; }
        public IEnumerable<UserProfileView> UserProfileList { get; set; }
    }
}