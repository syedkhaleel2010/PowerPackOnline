using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using PowerPack.Common.Enums;

namespace SIMS.API.Areas.Assessment.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly IAssessmentService _AssessmentService;


        public AssessmentController(IAssessmentService Assessment_Service)
        {
            _AssessmentService = Assessment_Service;

        }

        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 06/Aug/2019
        /// Description: To get the student list
        [HttpGet]
        [Route("GetStudentList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.StudentList>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentList(string GRD_ID, Int32 ACD_ID, Int32 SGR_ID, Int32 SCT_ID)
        {
            var result = await _AssessmentService.GetStudentList(GRD_ID, ACD_ID, SGR_ID, SCT_ID);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 06/Aug/2019
        /// Description: To get the report headers
        [HttpGet]
        [Route("GetReportHeaders")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.ReportHeader>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportHeaders(string GRD_ID, Int32 ACD_ID, Int32 SBG_ID, Int32 RPF_ID, Int32 RSM_ID, string prv = "", ReportHeaderType IsGradeBook = ReportHeaderType.GradeEntry)
        {
            var result = await _AssessmentService.GetReportHeaders(GRD_ID, ACD_ID, SBG_ID, RPF_ID, RSM_ID, prv, IsGradeBook);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 07/Aug/2019
        /// Description: To get the report headers dropdowns value
        [HttpGet]
        [Route("GetReportHeadersDropdowns")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.ReportHeaderDropDown>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportHeadersDropdowns(Int32 RSM_ID, Int32 SBG_ID, Int32 RSD_ID)
        {
            var result = await _AssessmentService.GetReportHeadersDropdowns(RSM_ID, SBG_ID, RSD_ID);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 14/Aug/2019
        /// Description: To get the previously entered assessment data (if any)
        [HttpGet]
        [Route("GetAssessmentData")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AssessmentData>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssessmentData(Int32 ACD_ID, Int32 SBG_ID, Int32 RPF_ID, Int32 RSM_ID, string prv = "")
        {
            var result = await _AssessmentService.GetAssessmentData(ACD_ID, SBG_ID, RPF_ID, RSM_ID, prv);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 15/Aug/2019
        /// Description: To insert/update the assessment details .
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertAssessmentData")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> InsertAssessmentData([FromBody] string student_xml, string username, int bEdit)
        {
            var result = await _AssessmentService.InsertAssessmentData(student_xml, username, bEdit);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAssessmentActivityList")]
        [ProducesResponseType(typeof(IEnumerable<MarkEntry>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssessmentActivityList(long ACD_ID = 0, long CAM_ID = 0, string GRD_ID = "", long STM_ID = 0, long TRM_ID = 0, long SGR_ID = 0, long SBG_ID = 0, int GRADE_ACCESS = 0, string Username = "", string SuperUser = "")
        {
            var result = await _AssessmentService.GetAssessmentActivityList(ACD_ID, CAM_ID, GRD_ID, STM_ID, TRM_ID, SGR_ID, SBG_ID, GRADE_ACCESS, Username, SuperUser);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 22/Aug/2019
        /// Description: To get the mark entry  data (if any)
        [HttpGet]
        [Route("GetMarkEntryData")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.MarkEntryData>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMarkEntryData(long CAS_ID, double MIN_MARK, double MAX_MARK)
        {
            var result = await _AssessmentService.GetMarkEntryData(CAS_ID, MIN_MARK, MAX_MARK);
            return Ok(result);
        }
        /// <summary>
        /// Created By: Fraz Ahmed
        /// Created On: 22/Aug/2019
        /// Description: To get the mark entry AOL  data (if any)
        [HttpGet]
        [Route("GetMarkEntryAOLData")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.MarkEntryAOLData>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMarkEntryAOLData(long CAS_ID)
        {
            var result = await _AssessmentService.GetMarkEntryAOLData(CAS_ID);
            return Ok(result);
        }

        [HttpPost]
        [Route("InsertMarkEntryAOLData")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> InsertMarkEntryAOLData(List<MarkEntryAOLData> lstmarkEntryAOLData, string Username, bool bWithoutSkill, long CAS_ID)
        {
            var result = _AssessmentService.InsertMarkEntryAOLData(lstmarkEntryAOLData, Username, bWithoutSkill, CAS_ID);
            return Ok(result);
        }

        [HttpPost]
        [Route("InsertMarkEntryData")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> InsertMarkEntryData(List<MarkEntryData> lstmarkEntryData, long SlabId, string entryType, long CAS_ID)
        {
            var result = _AssessmentService.InsertMarkEntryData(lstmarkEntryData, SlabId, entryType, CAS_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAssessmentComments")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AssessmentComments>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssessmentComments(int CAT_ID, long STU_ID)
        {
            var result = await _AssessmentService.GetAssessmentComments(CAT_ID, STU_ID);
            return Ok(result);

        }
        [HttpGet]
        [Route("GetHeaderBySubjectCategory")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AssessmentComments>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetHeaderBySubjectCategory(long SGRP_ID)
        {
            var result = await _AssessmentService.GetHeaderBySubjectCategory(SGRP_ID);
            return Ok(result);

        }

        [HttpGet]
        [Route("GetAssessmentCategories")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AssessmentCategory>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssessmentCategories(long CAT_BSU_ID, string CAT_GRD_ID)
        {
            var result = await _AssessmentService.GetAssessmentCategories(CAT_BSU_ID, CAT_GRD_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetSectionAccess")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.SectionAccess>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSectionAccess(string USERNAME, string IsSuperUser, long ACD_ID, long BSU_ID, int GRD_ACCESS, string GRD_ID)
        {
            var result = await _AssessmentService.GetSectionAccess(USERNAME, IsSuperUser, ACD_ID, BSU_ID, GRD_ACCESS, GRD_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetReportHeaderOptional")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.HeaderOptional>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportHeaderOptional(string AOD_IDs)
        {
            var result = await _AssessmentService.GetReportHeaderOptional(AOD_IDs);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAssessmentDataOptional")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AssessmentDataOptional>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssessmentDataOptional(long ACD_ID, long RPF_ID, long RSM_ID, long SBG_ID, long SGR_ID, string GRD_ID, long SCT_ID, string AOD_IDs)
        {
            var result = await _AssessmentService.GetAssessmentDataOptional(ACD_ID, RPF_ID, RSM_ID, SBG_ID, SGR_ID, GRD_ID, SCT_ID, AOD_IDs);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetAssessmentPreviousSchedule")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AssessmentPreviousSchedule>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssessmentPreviousSchedule(long ACD_ID, string GRD_ID)
        {
            var result = await _AssessmentService.GetAssessmentPreviousSchedule(ACD_ID, GRD_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAssessmentOptionList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.AssessmentOptionalList>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssessmentOptionList(long BSU_ID, long ACD_ID)
        {
            var result = await _AssessmentService.GetAssessmentOptionList(BSU_ID, ACD_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("IsReportPublish")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> IsReportPublish(long RPP_RSM_ID, long RPP_RPF_ID, long RPP_ACD_ID, string RPP_GRD_ID, long RPP_SCT_ID, long RPP_TRM_ID)
        {
            var result = await _AssessmentService.IsReportPublish(RPP_RSM_ID, RPP_RPF_ID, RPP_ACD_ID, RPP_GRD_ID, RPP_SCT_ID, RPP_TRM_ID);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateMarkAttendanceEntry")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> UpdateMarkAttendanceEntry(long CAS_ID,List<MarkAttendance> lstmarkAttendance)
        {
            var result = _AssessmentService.UpdateMarkAttendance(lstmarkAttendance, CAS_ID);
            return Ok(result);
        }


        #region Grade Book Setup
        [HttpGet]
        [Route("GetGradeScaleList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.GradeBookGradeScale>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradeScaleList(long BSU_ID, long ACD_ID, long TEACHER_ID)
        {
            var result = await _AssessmentService.GetGradeScaleList(BSU_ID, ACD_ID, TEACHER_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetGradeScaleDetailList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.GradeBookGradeScaleDetail>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradeScaleDetailList(long GSM_ID)
        {
            var result = await _AssessmentService.GetGradeScaleDetailList(GSM_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveGradeScaleAndDetail")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveGradeScaleAndDetail(GradeBookGradeScale gradeBookGradeScale, string DATAMODE)
        {
            var result = await _AssessmentService.SaveGradeScaleAndDetail(gradeBookGradeScale, DATAMODE);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveGradeBookSetup")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveGradeBookSetup(GradeBookSetup gradeBookSetup, string DATAMODE)
        {
            var result = await _AssessmentService.SaveGradeBookSetup(gradeBookSetup, DATAMODE);
            return Ok(result);
        }
        [HttpPost]
        [Route("GetGradeBookSetupList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.GradeBookSetup>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradeBookSetupList(GradeBookSetup gradeBookSetup)
        {
            var result = await _AssessmentService.GetGradeBookSetupList(gradeBookSetup);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetReportHeaderByRSMID")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.GradeBookSetup>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportHeaderByRSMID(long RSM_ID)
        {
            var result = await _AssessmentService.GetReportHeaderByRSMID(RSM_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetReportHeaderDDLByRSMID")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.GradeBookSetup>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportHeaderDDLByRSMID(long RSM_ID)
        {
            var result = await _AssessmentService.GetReportHeaderDDLByRSMID(RSM_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveProcessingRuleSetup")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveProcessingRuleSetup(ProcessingRuleSetup processingRuleSetup, string DATAMODE)
        {
            var result = await _AssessmentService.SaveProcessingRuleSetup(processingRuleSetup, DATAMODE);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetProcessingRuleSetupList")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.ProcessingRuleSetup>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProcessingRuleSetupList(long PRS_RSD_ID)
        {
            var result = await _AssessmentService.GetProcessingRuleSetupList(PRS_RSD_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetGradebookDetail")]
        [ProducesResponseType(typeof(IEnumerable<SIMS.API.Models.GradeBookDetail>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradebookDetail(long RSD_ID)
        {
            var result = await _AssessmentService.GetGradebookDetail(RSD_ID);
            return Ok(result);
        }
        #endregion


        #region Grade Book Entry
        [HttpPost]
        [Route("GradeBookCUD")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GradeBookCUD(GradeBookEntryListModel gradeBookEntry)
        {
            var result = await _AssessmentService.GradebookCUD(gradeBookEntry);
            return Ok(result);
        }

        #endregion

        [HttpGet]
        [Route("GetSubjectsForReportWriting")]
        [ProducesResponseType(typeof(IEnumerable<Subjects>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubjectsForReportWriting(long acdId, long studentId, string IsSuperUser, long employeeId)
        {
            var result = await _AssessmentService.GetSubjectsForReportWriting(acdId, studentId, IsSuperUser, employeeId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSavedRecordsOfReportWriting")]
        [ProducesResponseType(typeof(IEnumerable<Subjects>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSavedRecordsOfReportWriting(long rpfId, long studentId, string IsSuperUser, long employeeId)
        {
            var result = await _AssessmentService.GetSavedRecordsOfReportWriting(rpfId, studentId);
            return Ok(result);
        }
        [HttpPost]
        [Route("ReportWritingCU")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> ReportWritingCU(List<AssessmentData> assessmentDatas)
        {
            var result = await _AssessmentService.ReportWritingCU(assessmentDatas);
            return Ok(result);
        }
    }
}