using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerPack.Models
{
    public class PagePermission
    {
        public long UserId { get; set; }
        public int ModuleId { get; set; }
        public bool CanView { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }

    public class ModulePermission
    {
        public int ModuleId { get; set; }
        public string PermissionCategoryIds { get; set; }
    }


    public enum PermissionCategory
    {
        View = 1,
        AddEditDelete = 2,
        Add = 4,
        Update = 5,
        Delete = 6
    }

    public enum UserTypes
    {
        Admin = 1,
        User = 2,
        SuperAdmin = 3
    }
}