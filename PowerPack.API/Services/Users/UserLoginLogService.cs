using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerPack.Models.Entities;
using PowerPack.API.Repositories;

namespace PowerPack.API.Services
{
    public class UserLoginLogService : IUserLoginLogService
    {
        private readonly IUserLoginLogRepository logRepository;

        public UserLoginLogService(IUserLoginLogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        public async Task<long> InsertUserLoginLogs(UserLoginLogs loginLogs) =>
            await logRepository.InsertUserLoginLogs(loginLogs);
    }
}
