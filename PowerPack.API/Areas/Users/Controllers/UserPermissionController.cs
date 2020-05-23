using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using PowerPack.Common.Helpers;
using PowerPack.Models;

namespace SIMS.API.Areas.Users.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserPermissionController : ControllerBase
    {
        private readonly IUserPermissionService _userPermissionService;
        public UserPermissionController(IUserPermissionService userPermissionService)
        {
            _userPermissionService = userPermissionService;
        }

        /// <summary>
        /// CreatedBy: Deepak Singh
        /// CreatedOn: 29/May/2019
        /// Description: To check is permission assigned for the given url
        /// </summary>
        /// <param name="userId">long: userid</param>
        /// <param name="moduleUrl">string: moduleUrl</param>
        /// <param name="userTypeId">int: userTypeId</param>
        /// <returns></returns>
        [HttpGet]
        [Route("checkuserpermission")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CheckUserPermission(string userName, string moduleUrl, int userTypeId)
        {
            var decryptModuleUrl = EncryptDecryptHelper.DecryptUrl(moduleUrl);
            var result = _userPermissionService.IsPermissionAssigned(userName, decryptModuleUrl, userTypeId);
            return Ok(result);
        }

        /// <summary>
        /// CreatedBy: Deepak Singh
        /// CreatedOn: 29/May/2019
        /// Description: To get user all permission assigned 
        /// </summary>
        /// <param name="userId">long: userid</param>
        /// <param name="moduleUrl">string: moduleUrl</param>
        /// <param name="moduleCode">string: moduleCode</param>
        /// <param name="userTypeId">int: userTypeId</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getuserpermission")]
        [ProducesResponseType(typeof(PagePermission), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetUserPermission(string userId, string moduleUrl, string moduleCode, int userTypeId)
        {
            var decryptModuleUrl = EncryptDecryptHelper.DecryptUrl(moduleUrl);
            var decryptModuleCode = EncryptDecryptHelper.DecryptUrl(moduleCode);
            var result = _userPermissionService.GetUserPermissions(userId, decryptModuleUrl, decryptModuleCode, userTypeId);
            return Ok(result);
        }

        /// <summary>
        /// CreatedBy: Deepak Singh
        /// CreatedOn: 04/June/2019
        /// Description: To add menu item in PowerPack module structure and permission list
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addmenuitem")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public ActionResult AddMenuItem([FromBody]MenuItem menuItem)
        {
            var result = _userPermissionService.AddMenuItem(menuItem);
            return Ok(result > 0);
        }

        /// <summary>
        /// CreatedBy: Rohit Patil
        /// CreatedOn: 12/Jun/2019
        /// Description: To check is custom permission assigned
        /// </summary>
        /// <param name="userId">long: userid</param>
        /// <param name="permissionCodes">string: permission Codes</param>
        /// <returns></returns>
        [HttpGet]
        [Route("IsCustomPermissionAssigned")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult IsCustomPermissionAssigned(int userId, string permissionCodes)
        {
            var result = _userPermissionService.IsCustomPermissionAssigned(userId, permissionCodes);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetReportList")]
        [ProducesResponseType(typeof(IEnumerable<ModuleStructure>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportList()
        {
            var users = await _userPermissionService.GetReportList();
            return Ok(users);
        }
    }
}