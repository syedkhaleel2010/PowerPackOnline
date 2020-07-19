using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Services
{
    public interface IUserLoginLogService
    {
        Task<long> InsertUserLoginLogs(UserLoginLogs loginLogs);
    }
}
