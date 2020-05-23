using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models
{
    public class UserRole
    {
        public UserRole() { }
        public UserRole(int _userRoleId)
        {
            UserRoleId = _userRoleId;
        }
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public bool IsEditable { get; set; }
        public bool IsSelected { get; set; }
        public bool IsActive { get; set; }
        public bool ShowToAll { get; set; }
        public string Actions { get; set; }
        public long SchoolId { get; set; }
        public int UserCount { get; set; }
    }
}
