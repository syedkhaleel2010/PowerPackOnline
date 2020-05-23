using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface IErrorLoggerService
    {
        ErrorLog GetErrorLogs(string applicationName, int pageIndex, int pageSize, string search, string sortColumn, string sortColumnDir);
        Task<string> GetErrorLog(string applicationName, Guid errorId);
        Task<bool> LogError(ErrorLogModel error);
    }
}
