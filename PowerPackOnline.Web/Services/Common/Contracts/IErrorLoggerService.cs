using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerPackOnline.Web.Services
{
    public interface IErrorLoggerService
    {
        ErrorLog GetErrorLogs(string applicationName, int pageIndex, int pageSize, string search, string sortColumn, string sortColumnDir);
        string GetErrorLog(string applicationName, Guid errorId);
        bool LogError(Exception ex, HttpContext httpContext);
    }
}