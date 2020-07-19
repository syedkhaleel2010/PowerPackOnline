using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerPack.Models.Entities;
using PowerPack.API.Services;

namespace PowerPack.API.Areas.Users.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserLoginLogController : ControllerBase
    {
        private readonly IUserLoginLogService userLoginLogService;

        public UserLoginLogController(IUserLoginLogService userLoginLogService)
        {
            this.userLoginLogService = userLoginLogService;
        }

        /// <summary>
        /// Created By : 
        /// Created On : 22/April/2020
        /// Description: To save the user login logs
        /// </summary>
        /// <param name="userLoginLogs">user login log object</param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertUserLoginLogs")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> InsertUserLoginLogs([FromBody]UserLoginLogs userLoginLogs)
        {
            var result = await userLoginLogService.InsertUserLoginLogs(userLoginLogs);
            return Ok(result);
        }
    }
}