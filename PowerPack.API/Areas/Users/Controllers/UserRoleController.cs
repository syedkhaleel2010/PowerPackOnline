using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using PowerPack.Common.Models;
using PowerPack.Common.ViewModels;
using PowerPack.Models;

namespace SIMS.API.Areas.Users.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService UserRoleService)
        {
            _userRoleService = UserRoleService;
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 18 Apr 2019
        /// Description - To get all user roles.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getUserRoles")]
        [ProducesResponseType(typeof(IEnumerable<UserRole>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserRoles()
        {
            var modelList = await _userRoleService.GetUserRoles();
            return Ok(modelList);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 18 Apr 2019
        /// Description - To get all user roles.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getUserRolesbyschoolid/{schoolid:int}")]
        [ProducesResponseType(typeof(IEnumerable<UserRole>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserRoles(int schoolId)
        {
            var modelList = await _userRoleService.GetUserRolesBySchoolId(schoolId);
            return Ok(modelList);
        }

        /// <summary>
        /// Created By: Deepak singh
        /// Created On: 16 October 2019
        /// Description: To get users by role id for school
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getusersbyrole/{roleid:int}/{schoolid:int}")]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUsersForRole(int roleId, int schoolId)
        {
            var modelList = await _userRoleService.GetUsersForRole(roleId, schoolId);
            return Ok(modelList);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 19 Apr 2019
        /// Description - To get user role by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getUserRolebyid/{id:int}")]
        [ProducesResponseType(typeof(UserRole), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserRoleById(int id)
        {
            var model = await _userRoleService.GetUserRoleById(id);
            return Ok(model);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 19 Apr 2019
        /// Description - To insert user role
        /// </summary>
        /// <param name="UserRole"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insertUserRole")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> InsertUserRole([FromBody]UserRole UserRole)
        {
            var result = _userRoleService.InsertUserRole(UserRole);
            return Ok(result);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 19 Apr 2019
        /// Description - To update user role.
        /// </summary>
        /// <param name="UserRole"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateUserRole")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> UpdateUserRole([FromBody]UserRole UserRole)
        {
            var result = _userRoleService.UpdateUserRole(UserRole);
            return Ok(result);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 19 Apr 2019
        /// Description - To delete user role.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteUserRole/{id:int}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> DeleteUserRole(int id)
        {
            var result = _userRoleService.DeleteUserRole(id);
            return Ok(result);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 31 may 2019
        /// Description - To get All User Role Mapping User ID.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllUserRoleMappingData")]
        [ProducesResponseType(typeof(IEnumerable<UserRoleMapping>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllUserRoleMappingData(string userid, string schoolId = "")
        {
            var model = await _userRoleService.GetAllUserRoleMappingData(userid, schoolId);
            return Ok(model);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 31 may 2019
        /// Description - To Get Assigned User Mapping Data.
        /// </summary>
        /// <param name="systemlanguageid"></param>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getAssignedUserMappingData")]
        [ProducesResponseType(typeof(IEnumerable<UserRoleMapping>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssignedUserMappingData(int systemlanguageid, int roleid)
        {
            var model = await _userRoleService.GetAssignedUserMappingData(systemlanguageid, roleid);
            return Ok(model);
        }
        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 31 may 2019
        /// Description - To Get Module List.
        /// </summary>
        /// <param name="systemlanguageid"></param>
        /// <param name="modulecode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetModuleList")]
        [ProducesResponseType(typeof(IEnumerable<ModuleStructure>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetModuleList(int systemlanguageid, string modulecode)
        {
            var model = await _userRoleService.GetModuleList(systemlanguageid, modulecode);
            return Ok(model);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 31 may 2019
        /// Description - To Get User Role Permission List.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserRolePermissionList")]
        [ProducesResponseType(typeof(IEnumerable<ModuleStructure>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserRolePermissionList()
        {
            var model = await _userRoleService.GetUserRolePermissionList();
            return Ok(model);
        }
        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 31 may 2019
        /// Description - To Get Role Mapping Data.
        /// </summary>
        /// <param name="roleId"></param>
        /// /// <param name="schoolId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRoleMappingData")]
        [ProducesResponseType(typeof(IEnumerable<ModuleStructure>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRoleMappingData(int roleId, int schoolId)
        {
            var model = await _userRoleService.GetRoleMappingData(roleId, schoolId);
            return Ok(model);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 31 may 2019
        /// Description - To Get Module Structure List.
        /// </summary>
        /// <param name="systemlanguageid"></param>
        /// <param name="moduleid"></param>
        /// <param name="modulecode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetModuleStructureList")]
        [ProducesResponseType(typeof(IEnumerable<ModuleStructure>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetModuleStructureList(int systemlanguageid, int? moduleid, string modulecode)
        {
            var model = await _userRoleService.GetModuleStructureList(systemlanguageid, moduleid, modulecode);
            return Ok(model);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 06 jun 2019
        /// Description - To Get Module Structure List.
        /// </summary>
        /// <param name="userRoleId"></param>
        /// <param name="userId"></param>
        /// <param name="moduleId"></param>
        /// <param name="loadCustomPermission"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllPermissionData")]
        [ProducesResponseType(typeof(IEnumerable<PermissionTypeView>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllPermissionData(int userRoleId, int userId, int moduleId, bool loadCustomPermission, int schoolId)
        {
            var model = await _userRoleService.GetAllPermissionData(userRoleId, userId, moduleId, loadCustomPermission, schoolId);
            return Ok(model);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 07 jun 2019
        /// Description - To Update Permission Type Data CUD.
        /// </summary>
        /// <param name="updatePermissionDataWrapper"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePermissionTypeDataCUD")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdatePermissionTypeDataCUD([FromBody]UpdatePermissionDataWrapper updatePermissionDataWrapper)
        {
            var model = await _userRoleService.UpdatePermissionTypeDataCUD(updatePermissionDataWrapper.objCustomPermissionEditList, updatePermissionDataWrapper.OperationType, updatePermissionDataWrapper.UserId, updatePermissionDataWrapper.UserRoleId, updatePermissionDataWrapper.SchoolId);
            return Ok(model);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 13 jun 2019
        /// Description - To Check User Role Mapping.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckUserRoleMapping")]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CheckUserRoleMapping(string userid, short? roleid)
        {
            var model = await _userRoleService.CheckUserRoleMapping(userid, roleid);
            return Ok(model);
        }

        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 13 jun 2019
        /// Description - To Insert User Role Mapping Data.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("InsertUserRoleMappingData")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertUserRoleMappingData(string userid, short roleid)
        {
            var model = await _userRoleService.InsertUserRoleMappingData(userid, roleid);
            return Ok(model);
        }
        /// <summary>
        /// Created By - Rohit Patil
        /// Created Date - 13 jun 2019
        /// Description - To Delete User Role Mapping Data.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteUserRoleMappingData")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteUserRoleMappingData(string userid, short roleid)
        {
            var model = await _userRoleService.DeleteUserRoleMappingData(userid, roleid);
            return Ok(model);
        }

        [HttpGet]
        [Route("GetAllReportPermissionData")]
        [ProducesResponseType(typeof(IEnumerable<PermissionTypeView>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllReportPermissionData(int userRoleId, int moduleId, long schoolId, int isRoleId, int isUserId, int parentModuleId)
        {
            var model = await _userRoleService.GetAllReportPermissionData(userRoleId, moduleId, schoolId, isRoleId, isUserId, parentModuleId);
            return Ok(model);
        }

        [HttpPost]
        [Route("SetReportPermissionForUserAndRole")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SetReportPermissionForUserAndRole( string operationtype, int userRoleId, long schoolId, short IsUser, short IsRole, List<CustomPermissionEdit> MappingDetails)
        {
            var model = _userRoleService.SetReportPermissionForUserAndRole(MappingDetails, operationtype, userRoleId, schoolId, IsUser, IsRole);
            return Ok(model);
        }
    }
}