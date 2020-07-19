using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerPack.API.Services;
using PowerPack.API.Models;
using PowerPack.Common.Models;
using PowerPack.Models;
using PowerPack.Models.Entities;

namespace PowerPack.API.Areas.Users.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UsersController(IUserService UserService)
        {
            _UserService = UserService;
        }

        /// <summary>
        /// Author : 
        /// Created Date : 16-MAY-2019
        /// Description : To fetch all the users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getallusers")]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _UserService.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 18-JUNE-2019
        /// Description : To fetch all the user feelings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getalluserfeelings")]
        [ProducesResponseType(typeof(IEnumerable<UserFeelingView>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllUserFeelingsAsync()
        {
            var userFeelings = await _UserService.GetUserFeelings();
            return Ok(userFeelings);
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 23-JUNE-2019
        /// Description : To fetch all the user avatar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getprofileavatars")]
        [ProducesResponseType(typeof(IEnumerable<UserProfileView>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProfileAvatars()
        {
            var profileAvatars = await _UserService.GetProfileAvatars();
            return Ok(profileAvatars);
        }

        /// <summary>
        /// Author : 
        /// Created Date : 13-June-2019
        /// Description :  To fetch user by role and location allowed to access
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getusersbyrolelocation")]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUsersByRoleLocationsAsync(string roles, int businessUnitId = 0)
        {
            var users = await _UserService.GetUsersByRolesLocatonAllowed(roles, businessUnitId);
            return Ok(users);
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 18-JUNE-2019
        /// Description : To fetch Update user feelings
        /// </summary>
        /// <param name="userFeelingView"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateuserfeeling")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> UpdateUserFeeling([FromBody]UserFeelingView userFeelingView)
        {
            var result = _UserService.UpdateUserFeeling(userFeelingView);
            return Ok(result);
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 24-JUNE-2019
        /// Description : To UpdateUserProfile
        /// </summary>
        /// <param name="userFeelingView"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateuserprofile")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> UpdateUserProfile([FromBody]UserProfileView userProfileView)
        {
            var result = _UserService.UpdateUserProfile(userProfileView);
            return Ok(result);
        }

        /// <summary>
        /// Author : Girish Sonawane
        /// Created Date : 16-OCT-2019
        /// Description : Insert notofication log
        /// </summary>
        /// <param name="notificationType"></param>
        /// <param name="sourceId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("pushnotificationlogs")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> PushNotificationLogs(string notificationType, int sourceId, long userId)
        {
            var result = _UserService.PushNotificationLogs(notificationType, sourceId, userId);
            return Ok(result);
        }

        /// <summary>
        /// Author : 
        /// Created Date : 16-MAY-2019
        /// Description : To fetch all users filtered by  id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getusersbyschool")]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUsersBySchool(int? id, int userTypeId)
        {
            var users = await _UserService.GetUserBySchool(id, userTypeId);
            return Ok(users);
        }

        /// <summary>
        /// Author : Girish Sonawane 
        /// Created Date : 15/10/2019
        /// Description : To get user notifications
        /// </summary>
        /// <param name="userTypeId"></param>
        /// <param name="userId"></param>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getusernotifications")]
        [ProducesResponseType(typeof(IEnumerable<UserNotificationView>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserNotifications(int? userTypeId, long userId, long loginUserId)
        {
            var notifications = await _UserService.GetUserNotifications(userTypeId, userId, loginUserId);
            return Ok(notifications);
        }

        /// <summary>
        /// Author : Girish Sonawane 
        /// Created Date : 15/10/2019
        /// Description : To get all notifications
        /// </summary>
        /// <param name="userTypeId"></param>
        /// <param name="userId"></param>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getallnotifications")]
        [ProducesResponseType(typeof(IEnumerable<UserNotificationView>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllNotifications(int? userTypeId, long userId, long loginUserId)
        {
            var notifications = await _UserService.GetAllNotifications(userTypeId, userId, loginUserId);
            return Ok(notifications);
        }

        /// <summary>
        /// Author : 
        /// Created Date : 16-MAY-2019
        /// Description : To fetch all user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getuserbyid")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _UserService.GetUserById(id);
            return Ok(user);
        }

        /// <summary>
        /// Author : 
        /// Created Date : 19-MAY-2019
        /// Description : To search users by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typId"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("searchuserbyname")]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SearchUserByName(string name, int typId = 0, int Id = 0)
        {
            var user = await _UserService.SearchUserByName(name, typId, Id);
            return Ok(user);
        }
        /// <summary>
        /// Author : Mahesh Chikhale
        /// Created Date : 21th Oct 2019
        /// Description : To fetch Update user feelings
        /// </summary>
        /// <param name="errorLogger"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("saveErrorLogger")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> saveErrorLogger([FromBody]ErrorLogger errorLogger)
        {
            var result = _UserService.saveErrorLogger(errorLogger);
            return Ok(result);
        }
        /// <summary>
        /// Author : Mahesh Chikhale
        /// Created Date : 21-Oct-2019
        /// Description : To get DB process details after error logged by user
        /// </summary>

        /// <returns></returns>
        [HttpGet]
        [Route("GetDBLogdetails")]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDBLogDetails()
        {
            var users = await _UserService.GetDBLogdetails();
            return Ok(users);
        }

    }
}
