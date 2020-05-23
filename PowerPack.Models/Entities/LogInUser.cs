using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models
{
    public class LogInUser
    {
        public LogInUser()
        {

        }

        public LogInUser(int id)
        {
            Id = id;
        }
        public Int64 Id { get; set; }

        public Int64 OldUserId { get; set; }
        public Int64 SchoolId { get; set; }
        public string SchoolBusinessUnitName { get; set; }
        public string SchoolBusinessUnitCode { get; set; }
        public string SchoolBusinessUnitEmail { get; set; }
        public int SchoolBusinessUnitTypeId { get; set; }
        public string SchoolBusinessUnitType { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }


        public string FirstName { get; set; }
        public string  MiddleName { get; set; }
        public string  LastName { get; set; }

        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSuperAdmin { get; set; }
        public string UserDisplayName { get; set; }
        public int LanguageId { get; set; }
        public string SchoolImage { get; set; }
        public string ProfilePhoto { get; set; }
        public string UserAvatar { get; set; }

        public int UserStatusId { get; set; }
        public string UserStatus { get; set; }
        //API Authenticated token
        public string Token { get; set; }
    }
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
