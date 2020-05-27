using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPackOnline.Web.Services
{
    public interface IUserLoginLogService
    {
        long InsertUserLoginLogs(UserLoginLogs userLoginLogs);
    }
}
