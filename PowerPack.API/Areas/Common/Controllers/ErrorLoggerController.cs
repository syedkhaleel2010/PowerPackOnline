using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerPack.Models.Entities;
using SIMS.API.Services;

namespace SIMS.API.Areas.Common.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ErrorLoggerController : ControllerBase
    {
        private readonly IErrorLoggerService errorLoggerService;

        public ErrorLoggerController(IErrorLoggerService errorLoggerService)
        {
            this.errorLoggerService = errorLoggerService;
        }

        [HttpGet]
        [Route("GetErrorLog")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetErrorLog(string applicationName, Guid errorId)
        {
            var result = await errorLoggerService.GetErrorLog(applicationName, errorId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetErrorLogs")]
        [ProducesResponseType(typeof(ErrorLog), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetErrorLogs(string applicationName, int pageIndex, int pageSize, string search, string sortColumn, string sortColumnDir)
        {
            var result = errorLoggerService.GetErrorLogs(applicationName, pageIndex, pageSize, search,sortColumn,sortColumnDir);
            return Ok(result);
        }

        [HttpPost]
        [Route("LogError")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LogError(ErrorLogModel error)
        {
            var result = await errorLoggerService.LogError(error);
            return Ok(result);
        }
    }
}