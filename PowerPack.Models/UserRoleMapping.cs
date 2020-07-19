using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models
{
    public class UserRoleMapping
    {
        public UserRoleMapping() { }
        public UserRoleMapping(int _userRoleId)
        {
            UserRoleId = _userRoleId;
        }
        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; }
        public bool IsEditable { get; set; }
        public bool IsSelected { get; set; }
        public bool IsActive { get; set; }
        public string Actions { get; set; }
    }
}
