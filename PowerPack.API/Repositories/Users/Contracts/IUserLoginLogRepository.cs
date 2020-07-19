using DbConnection;
using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Repositories
{
    public interface IUserLoginLogRepository : IGenericRepository<UserLoginLogs>
    {
        Task<long> InsertUserLoginLogs(UserLoginLogs loginLogs);
    }
}
