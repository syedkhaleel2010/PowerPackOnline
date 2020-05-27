using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PowerPackOnline.Web.Services
{
    public interface ILogInUserService
    {
        LogInUser GetLoginUserByUserName(string userName, string Password);
        IEnumerable<LogInUser> GetUserList(int schoolId);
    }
}
