using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SIMS.API.Services
{
    public interface ILogInUserService
    {
        Task<LogInUser> GetLoginUserByUserName(string userName,string Password);
        Task<IEnumerable<LogInUser>> GetUserList(int schoolId);
    }
}
