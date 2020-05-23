using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using PowerPack.Models;
using System.Web;
using PowerPack.Common.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace SIMS.API.Areas.Users.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly ILogInUserService _logInUserService;

        public LoginUserController(ILogInUserService logInUserService)
        {
            _logInUserService = logInUserService;
        }

        /// <summary>
        /// CreatedBy: Deepak Singh
        /// CreatedOn: 05/May/2019
        /// Description: To get login user details by username
        /// </summary>
        /// <param name="userName">username</param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        [Route("getloginuserbyusername")]
        [ProducesResponseType(typeof(IEnumerable<LogInUser>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserRoles(LoginModel login)
        {
            //var decryptUserName = EncryptDecryptHelper.DecryptUrl(userName);
            var result = await _logInUserService.GetLoginUserByUserName(login.UserName, login.Password);

            return Ok(result);
        }

        /// <summary>
        /// CreatedBy: Rohit Patil
        /// CreatedOn: 05/May/2019
        /// Description: To get all user details filtered by school
        /// </summary>
        /// <param name="schoolId">schoolId</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getuserlist/{schoolId:int}")]
        [ProducesResponseType(typeof(IEnumerable<LogInUser>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserList(int schoolId)
        {
            var result = await _logInUserService.GetUserList(schoolId);
            return Ok(result);
        }
    }
}