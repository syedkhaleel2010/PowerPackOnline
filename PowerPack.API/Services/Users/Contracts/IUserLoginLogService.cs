using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface IUserLoginLogService
    {
        Task<long> InsertUserLoginLogs(UserLoginLogs loginLogs);
    }
}
