using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerPack.Models.Entities;
using SIMS.API.Repositories;

namespace SIMS.API.Services
{
    public class ErrorLoggerService : IErrorLoggerService
    {
        private readonly IErrorLoggerRepository errorLoggerRepository;

        public ErrorLoggerService(IErrorLoggerRepository errorLoggerRepository)
        {
            this.errorLoggerRepository = errorLoggerRepository;
        }
        public async Task<string> GetErrorLog(string applicationName, Guid errorId) =>
            await errorLoggerRepository.GetErrorLog(applicationName, errorId);

        public ErrorLog GetErrorLogs(string applicationName, int pageIndex, int pageSize, string search, string sortColumn, string sortColumnDir) =>
            errorLoggerRepository.GetErrorLogs(applicationName, pageIndex, pageSize, search,sortColumn,sortColumnDir);

        public async Task<bool> LogError(ErrorLogModel error) =>
            await errorLoggerRepository.LogError(error);
    }
}
