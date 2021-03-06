﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models
{
    public class User
    {
        public User() { }

        public User(long id)
        {
            Id = id;
        }
        public long Id { get; set; }

        public int OldUserId { get; set; }
        public int StoreId { get; set; }
        public string StoreBusinessUnitName { get; set; }
        public string StoreBusinessUnitCode { get; set; }
        public string StoreBusinessUnitEmail { get; set; }
        public string StoreBusinessUnitTypeId { get; set; }
        public string StoreBusinessUnitType { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public bool IsSuperAdmin { get; set; }
        public string UserDisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Occupation { get; set; }
        public string Company { get; set; }
        public string Class { get; set; }
        public string StoreName { get; set; }
        public int FeelId { get; set; }
        public string CureentStatus { get; set; }
        public string FeelType { get; set; }
        public string FeelLogo { get; set; }
        public string ProfilePhoto { get; set; }
        public string UserAvatar { get; set; }
        public int UserStatusId { get; set; }
        public string UserStatus { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string UserImageFilePath { get; set; }
    }

}
