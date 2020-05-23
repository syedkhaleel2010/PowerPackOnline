using PowerPack.Common.Models;
using System.Collections.Generic;

namespace PowerPack.Common.ViewModels
{
    public class AssignUserRoleView
    {
        public short? UserId { get; set; }
        public string Username { get; set; }
        public IEnumerable<ListItem> UserList { get; set; }
        public IEnumerable<UserRolesList> UserRolesList { get; set; }
    }

    public class AssignUsersView
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<ListItem> UserRolesList { get; set; }
        public IEnumerable<UserList> UnAssignedUserList { get; set; }
        public IEnumerable<UserList> AssignedUserList { get; set; }
    }

    public class UserRolesList
    {
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public bool IsSelected { get; set; }
    }

    public class UserList
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
