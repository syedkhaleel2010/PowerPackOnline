//using Microsoft.AspNetCore.Mvc;
//using SIMS.API.Services;
//using SIMS.API.Models;
//using System.Collections.Generic;
//using System.Net;
//using System.Threading.Tasks;
//using System;

//namespace SIMS.API.Controllers
//{
//    [Route("api/v1/[controller]")]
//    [ApiController]
//    public class TimeTableController : ControllerBase
//    {
//        private readonly ITimeTableService _TimeTableService;

//        public TimeTableController(ITimeTableService TimeTable_Service)
//        {
//            _TimeTableService = TimeTable_Service;
//        }

//        /// <summary>
//        /// Created By: Fraz Ahmed
//        /// Created On: 13/June/2019
//        /// Description: To get the current month dates for timetable purpose
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        [Route("GetCurrentMonth")]
//        [ProducesResponseType(typeof(IEnumerable<CalenderMonth>), (int)HttpStatusCode.OK)]
//        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
//        public async Task<IActionResult> GetCurrentMonth()
//        {
//            var result = await _TimeTableService.GetCurrentMonth();
//            return Ok(result);
//        }

//        /// <summary>
//        /// Created By: Fraz Ahmed
//        /// Created On: 27/May/2019
//        /// Description: To get Grades list from Grades master table
//        /// </summary>
//        /// <param name="id">acd id</param>
//        /// <returns></returns>
//        [HttpGet]
//        [Route("GetTimeTablesByUserandDate")]
//        [ProducesResponseType(typeof(Grades), (int)HttpStatusCode.OK)]
//        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
//        public async Task<IActionResult> GetTimeTablesByUserandDate(string username, DateTime dateTime, string type, string grade = null, string section = null)
//        {
//            var result = await _TimeTableService.GetTimeTablesByUserandDate(username, dateTime, type, grade, section);
//            return Ok(result);
//        }
//        ///// <summary>
//        ///// Created By: Fraz Ahmed
//        ///// Created On: 28/May/2019
//        ///// Description: To get Sections list from Sections master table
//        ///// </summary>
//        ///// <param name="id">grd id</param>
//        ///// <returns></returns>
//        //[HttpGet]
//        //[Route("GetSectionsByGrade")]
//        //[ProducesResponseType(typeof(Sections), (int)HttpStatusCode.OK)]
//        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
//        //public async Task<IActionResult> GetSectionsByGrade(int id)
//        //{
//        //    var result = await _GradeService.GetSectionsByGrade(id);
//        //    return Ok(result);
//        //}
//    }

//}