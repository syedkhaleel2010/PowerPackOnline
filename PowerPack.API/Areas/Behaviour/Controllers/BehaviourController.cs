using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Areas.Behaviour.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BehaviourController : ControllerBase
    {
        private readonly IBehaviourService _BehaviourService;
        private readonly IClassListService classListService;

        public BehaviourController(IBehaviourService Behaviour_Service, IClassListService classListService)
        {
            _BehaviourService = Behaviour_Service;
            this.classListService = classListService;
        }

        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 20/June/2019
        /// Description: To get the class list from timetable id or grade and section.
        /// <param name="tt_id">TimeTable id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStudentList")]
        [ProducesResponseType(typeof(IEnumerable<ClassList>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentList(string username, int tt_id = 0, string grade = null, string section = null)
        {
            var result = await _BehaviourService.GetStudentList(username, tt_id, grade, section);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 14/July/2019
        /// Description: To load the behaviour details by student id.
        /// <param name="stu_id">Student id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LoadBehaviourByStudentId")]
        [ProducesResponseType(typeof(IEnumerable<ClassList>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoadBehaviourByStudentId(string stu_id)
        {
            var result = await _BehaviourService.LoadBehaviourByStudentId(stu_id);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 14/July/2019
        /// Description: To load the behaviour details by behaviour id.
        /// <param name="id">Behaviour id </param>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBehaviourById")]
        [ProducesResponseType(typeof(IEnumerable<BehaviorDetails>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBehaviourById(int id)
        {
            var result = await _BehaviourService.GetBehaviourById(id);
            return Ok(result);
        }

        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 17/July/2019
        /// Description: To insert/update the behaviour details by behaviour id.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertBehaviourDetails")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> InsertBehaviourDetails(string bsu_id, string mode,[FromBody] BehaviourDetails entity)
        {
            var result = await _BehaviourService.InsertBehaviourDetails(entity, bsu_id, mode);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetListOfStudentBehaviour")]
        [ProducesResponseType(typeof(IEnumerable<StudentBehaviour>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetListOfStudentBehaviour()
        {
            var result = await _BehaviourService.GetListOfStudentBehaviour();
            return Ok(result);
        }

        [HttpPost]
        [Route("InsertUpdateStudentBehavior")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> InsertUpdateStudentBehavior(List<StudentBehaviourFiles>lstbehaviourfiles,long studentId =0,int behaviourId =0, string behaviourComment = "")
        {
            var result =  _BehaviourService.InsertUpdateStudentBehavior(lstbehaviourfiles, studentId,behaviourId,behaviourComment);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetStudentBehaviorByStudentId")]
        [ProducesResponseType(typeof(IEnumerable<StudentBehaviour>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentBehaviorByStudentId(long studentId =0)
        {
            var result = await _BehaviourService.GetStudentBehaviorByStudentId(studentId);
            return Ok(result);
        }

        [HttpPost]
        [Route("InsertBulkStudentBehaviour")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> InsertBulkStudentBehaviour(List<StudentBehaviourFiles> studentBehaviourFiles,string bulkStudentIds, int behaviourId = 0, string behaviourComment = "")
        {
            var result = _BehaviourService.InsertBulkStudentBehaviour(studentBehaviourFiles,bulkStudentIds, behaviourId,behaviourComment);
            return Ok(result);
        }

        [HttpGet]
        [Route("UpdateBehaviourTypes")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> UpdateBehaviourTypes(int behaviourId=0,string behaviourType = "",int behaviourPoint =0, int categoryId=0)
        {
            var result = _BehaviourService.UpdateBehaviourTypes(behaviourId, behaviourType, behaviourPoint,categoryId);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetFileDetailsByStudentId")]
        [ProducesResponseType(typeof(IEnumerable<StudentBehaviourMerit>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetFileDetailsByStudentId(long studentId = 0)
        {
            var result = await _BehaviourService.GetFileDetailsByStudentId(studentId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetBehaviourClassList")]
        [ProducesResponseType(typeof(IEnumerable<ClassList>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBehaviourClassList(string username, int tt_id = 0, string grade = null, string section = null)
        {
            var result = await _BehaviourService.GetBehaviourClassList(username, tt_id, grade, section);
            return Ok(result);
        }


        [HttpGet]
        [Route("DeleteStudentBehaviourMapping")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> DeleteStudentBehaviourMapping(long studentId = 0, int behaviourId = 0)
        {
            var result =  _BehaviourService.DeleteStudentBehaviourMapping(studentId, behaviourId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSubCategoriesByCategoryId")]
        [ProducesResponseType(typeof(IEnumerable<SubCategories>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubCategoriesByCategoryId(long categoryId, string BSU_ID, string GRD_ID)
        {
            var result = await _BehaviourService.GetSubCategoriesByCategoryId(categoryId, BSU_ID, GRD_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetMeritDetails")]
        [ProducesResponseType(typeof(IEnumerable<StudentBehaviourMerit>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMeritDetails(int acdId, string schoolId, long studentId)
        {
            var result = await _BehaviourService.GetMeritDetails( acdId,  schoolId,  studentId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetMeritCategoryByStudent")]
        [ProducesResponseType(typeof(IEnumerable<SubCategories>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMeritCategoryByStudent(int acdId, string schoolId, long studentId)
        {
            var result = await _BehaviourService.GetMeritCategoryByStudent(acdId, schoolId, studentId);
            return Ok(result);
        }

        [HttpPost]
        [Route("InsertMeritDemerit")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> InsertMeritDemerit(string schoolId, int academicId, MeritDemerit objMeritDemerit)
        {
            var result = _BehaviourService.InsertMeritDemerit(schoolId,academicId, objMeritDemerit);
            return Ok(result);
        }



        #region Incident
        [HttpGet]
        [Route("GetIncidentList")]
        [ProducesResponseType(typeof(IEnumerable<IncidentListModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetIncidentList(long schoolId = 0, long academicYearId = 0, int month = 0 , long incidentId = 0)
        {
            List<IncidentListModel> incidentLists = new List<IncidentListModel>();
            if(incidentId == 0)
                incidentLists = (List<IncidentListModel>)await _BehaviourService.GetIncidentList(schoolId,academicYearId,month, incidentId);
            else
            {
                incidentLists = (List<IncidentListModel>)await _BehaviourService.GetIncidentList(schoolId, academicYearId, month, incidentId);
                var studentList = await _BehaviourService.GetIncidentStudentList(incidentId);
                var witnessList = await _BehaviourService.GetIncidentWitnesses(incidentId);
                if(incidentLists.Count > 0)
                {
                    incidentLists[0].IncidentStudentLists = studentList;
                    incidentLists[0].IncidentWitnesses = witnessList;
                }
            }
            return Ok(incidentLists);
        }

        [HttpGet]
        [Route("GetIncidentStudentList")]
        [ProducesResponseType(typeof(IEnumerable<IncidentListModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetIncidentStudentList(long IncidentId)
        {
            var result = await _BehaviourService.GetIncidentStudentList(IncidentId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetIncidentChart")]
        [ProducesResponseType(typeof(IEnumerable<ChartModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetIncidentChart(long schoolId, long academicYearId, int month, bool isCategory)
        {
            var result = await _BehaviourService.GetIncidentChartByCategory(schoolId, academicYearId, month, isCategory);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetIncidentStaffLists")]
        [ProducesResponseType(typeof(IEnumerable<IncidentStaffList>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetIncidentStaffLists(long schoolId, long academicYearId, int month, bool isCategory)
        {
            var result = await _BehaviourService.GetIncidentStaffLists(schoolId);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetIncidentEntryCUD")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> GetIncidentEntryCUD(IncidentEntry incidentEntry)
        {
            var result = await  _BehaviourService.IncidentEntryCUD(incidentEntry);
            return Ok(result);
        }

        #region IncidentAction
        [HttpGet]
        [Route("GetBehaviourAction")]
        [ProducesResponseType(typeof(BehaviourAction), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> GetBehaviourAction(long incidentId, long studentId)
        {
            var student = await classListService.GetStudentDetails(studentId.ToString());
            var result = await _BehaviourService.GetBehaviourAction(incidentId, studentId);
            if (result != null)
                result.StudentDetails = student;
            else
            {
                result = new BehaviourAction();
                result.StudentDetails = student;
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetBehaviourActionFollowups")]
        [ProducesResponseType(typeof(IEnumerable<BehaviourActionFollowup>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBehaviourActionFollowups(long incidentId, long actionId)
        {
            var result = await _BehaviourService.GetBehaviourActionFollowups(incidentId, actionId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetFollowUpDesignations")]
        [ProducesResponseType(typeof(IEnumerable<FollowUpDesignation>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetFollowUpDesignations(long schoolId, long incidentId)
        {
            var result = await _BehaviourService.GetFollowUpDesignations(schoolId, incidentId);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetFollowUpStaffs")]
        [ProducesResponseType(typeof(IEnumerable<FollowUpStaff>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetFollowUpStaffs(long schoolId, long designationId)
        {
            var result = await _BehaviourService.GetFollowUpStaffs(schoolId,designationId);
            return Ok(result);
        }

        [HttpPost]
        [Route("ActionCUD")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> ActionCUD(BehaviourAction behaviourAction)
        {
            var result = await _BehaviourService.ActionCUD(behaviourAction);
            return Ok(result);
        }

        [HttpPost]
        [Route("ActionFollowUpCUD")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> ActionFollowUpCUD(BehaviourActionFollowup behaviourActionFollowup)
        {
            var result = await _BehaviourService.ActionFollowUpCUD(behaviourActionFollowup);
            return Ok(result);
        }
        #endregion
        #endregion


        [HttpGet]
        [Route("GetStudentPointCategory")]
        [ProducesResponseType(typeof(IEnumerable<StudentPointCategory>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentPointCategory(int schoolId, long academicYearId, int scheduleType)
        {
            var result = await _BehaviourService.GetStudentPointCategory(schoolId, academicYearId,scheduleType);
            return Ok(result);
        }

        [HttpPost]
        [Route("CertificateProcessLogCU")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CertificateProcessLogCU(List<CertificateProcessLog> processLogs)
        {
            var result = await _BehaviourService.CertificateProcessLogCU(processLogs);
            return Ok(result);
        }

    }
}