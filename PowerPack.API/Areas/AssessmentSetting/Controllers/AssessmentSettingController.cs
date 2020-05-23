using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIMS.API.Models;
using SIMS.API.Services;

namespace SIMS.API.Areas.AssessmentSetting.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AssessmentSettingController : ControllerBase
    {
        private readonly IAssessmentSettingService assessmentSettingService;

        public AssessmentSettingController(IAssessmentSettingService assessmentSettingService)
        {
            this.assessmentSettingService = assessmentSettingService;
        }

        #region Other Configuration Setting

        #region Dhanaji Patil
        [HttpGet]
        [Route("GetAbsenteeSetting")]
        [ProducesResponseType(typeof(IEnumerable<AbsenteeSettingModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAbsenteeSetting(long BSU_ID, long ACD_ID)
        {
            var result = await assessmentSettingService.GetAbsenteeSetting(BSU_ID, ACD_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveAbsenteeSetting")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveAbsenteeSetting(AbsenteeSettingModel absenteeSettingModel)
        {
            var result = await assessmentSettingService.SaveAbsenteeSetting(absenteeSettingModel);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetReportDesignNameList")]
        [ProducesResponseType(typeof(IEnumerable<ReportDesignName>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportDesignNameList(long BSU_ID, long ACD_ID)
        {
            var result = await assessmentSettingService.GetReportDesignNameList(BSU_ID, ACD_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetReportDesignLinkList")]
        [ProducesResponseType(typeof(IEnumerable<ReportDesignLink>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportDesignLinkList(long BSU_ID, long ACD_ID)
        {
            var result = await assessmentSettingService.GetReportDesignLinkList(BSU_ID, ACD_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveReportDesignLink")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveReportDesignLink(ReportDesignLink reportDesignLink, string DATAMODE)
        {
            var result = await assessmentSettingService.SaveReportDesignLink(reportDesignLink, DATAMODE);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetReportRuleList")]
        [ProducesResponseType(typeof(IEnumerable<RuleSetupModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportRuleList(long ACD_ID, string GRD_ID, long STM_ID, long SBG_ID, long TRM_ID, long RRM_ID)
        {
            var result = await assessmentSettingService.GetReportRuleList(ACD_ID, GRD_ID, STM_ID, SBG_ID, TRM_ID, RRM_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveRuleSetup")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveRuleSetup(RuleSetupModel ruleSetupModel)
        {
            var result = await assessmentSettingService.SaveRuleSetup(ruleSetupModel);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAssesmentWithTypeList")]
        [ProducesResponseType(typeof(IEnumerable<AssesmentWithType>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssesmentWithTypeList(long ACD_ID, long TRM_ID)
        {
            var result = await assessmentSettingService.GetAssesmentWithTypeList(ACD_ID, TRM_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetReportScheduleDetail")]
        [ProducesResponseType(typeof(IEnumerable<AssesmentWithType>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReportScheduleDetail(long RRM_ID)
        {
            var result = await assessmentSettingService.GetReportScheduleDetail(RRM_ID);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteAppliedReportRule")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> DeleteAppliedReportRule(long RSS_ID)
        {
            var result = await assessmentSettingService.DeleteAppliedReportRule(RSS_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("GePublishedReportList")]
        [ProducesResponseType(typeof(IEnumerable<PublishedReportModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GePublishedReportList(long ACD_ID, string GRD_ID, long TRM_ID, long RSM_ID, long RPF_ID, int GRADE_ACCESS, string USERNAME)
        {
            var result = await assessmentSettingService.GePublishedReportList(ACD_ID, GRD_ID, TRM_ID, RSM_ID, RPF_ID, GRADE_ACCESS, USERNAME);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveUnpublishedReport")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveUnpublishedReport(UnpublishedReportData objUnpublishedReport, string userName)
        {
            var result = await assessmentSettingService.SaveUnpublishedReport(objUnpublishedReport, userName);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetSubjectSpecificList")]
        [ProducesResponseType(typeof(IEnumerable<SubjectSpecificCriteria>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubjectSpecificList(long RSM_ID, long SBG_ID)
        {
            var result = await assessmentSettingService.GetSubjectSpecificList(RSM_ID, SBG_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveSubjectSpecificCriteria")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveSubjectSpecificCriteria(SubjectSpecificCriteriaData ObjSubjectSpecificCriteria)
        {
            var result = await assessmentSettingService.SaveSubjectSpecificCriteria(ObjSubjectSpecificCriteria);
            return Ok(result);
        }
        #endregion

        [HttpGet]
        [Route("GetDefaultListById")]
        [ProducesResponseType(typeof(IEnumerable<AssessmentDescriptor>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDefaultListById(long RDM_ID)
        {
            var result = await assessmentSettingService.GetDefaultListById(RDM_ID);
            return Ok(result);
        }

        [HttpPost]
        [Route("OtherSettings_DefaultListCUD")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> OtherSettings_DefaultListCUD(long RDM_ID, long BSU_ID, string DEFAULT_DESCR, string DATAMODE, List<AssessmentDescriptor> objAssessmentDescriptor)
        {
            var result = assessmentSettingService.OtherSettings_DefaultListCUD(RDM_ID, BSU_ID, DEFAULT_DESCR, DATAMODE, objAssessmentDescriptor);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSubjectCategory")]
        [ProducesResponseType(typeof(IEnumerable<SubjectCategoryModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubjectCategory(long SBG_ID)
        {
            var result = await assessmentSettingService.GetSubjectCategory(SBG_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("OtherSettings_SubjectCategoryCUD")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> OtherSettings_SubjectCategoryCUD(SubjectCategoryModel SubjectCategoryModel)
        {
            var result = await assessmentSettingService.OtherSettings_SubjectCategoryCUD(SubjectCategoryModel);
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveDefaultValues")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveDefaultValues(DefaultValues defaultValues)
        {
            var result = await assessmentSettingService.SaveDefaultValues(defaultValues);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDefaultValues")]
        [ProducesResponseType(typeof(IEnumerable<DefaultValues>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDefaultValues(long RSM_ID)
        {
            var result = await assessmentSettingService.GetDefaultValues(RSM_ID);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetCourseContent")]
        [ProducesResponseType(typeof(CourseContent), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCourseContent(CourseContentParameter courseContentParameter)
        {
            var result = await assessmentSettingService.GetCourseContent(courseContentParameter);
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveCourseContent")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveCourseContent(CourseContent courseContent)
        {
            var result = await assessmentSettingService.SaveCourseContent(courseContent);
            return Ok(result);
        }
        #endregion     

        #region Assessment Configuration
        [HttpGet]
        [Route("GetAssessmentSettings")]
        [ProducesResponseType(typeof(IEnumerable<AssessmentSettings>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssessmentSettings(long acdId, long schoolId, int divisionId)
        {
            var result = await assessmentSettingService.GetAssessmentSettings(acdId, schoolId, divisionId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAssessmentConfigs")]
        [ProducesResponseType(typeof(IEnumerable<AssessmentConfig>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAssessmentConfigs(long rsmId, long AcdId, long schoolId)
        {
            var result = await assessmentSettingService.GetAssessmentConfigs(rsmId, AcdId, schoolId);
            return Ok(result);
        }

        [HttpPost]
        [Route("AssessmentConfigCUD")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AssessmentConfigCUD(AssessmentConfig assessmentConfig)
        {
            var result = await assessmentSettingService.AssessmentConfigCUD(assessmentConfig);
            return Ok(result);
        }
        #endregion

        #region Reflection Setup
        [HttpGet]
        [Route("GetOutComeList")]
        [ProducesResponseType(typeof(IEnumerable<OutComeModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOutComeList(long ACD_ID, long BSU_ID, long TRM_ID, string GRD_ID, long SBG_ID)
        {
            var result = await assessmentSettingService.GetOutComeList(ACD_ID, BSU_ID, TRM_ID, GRD_ID, SBG_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveReflectionSetup")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveReflectionSetup(ReflectionSetupModel reflectionSetupModel, string DATAMODE)
        {
            var result = await assessmentSettingService.SaveReflectionSetup(reflectionSetupModel, DATAMODE);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetReflectionSetupList")]
        [ProducesResponseType(typeof(IEnumerable<ReflectionSetupModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReflectionSetupList(long ACD_ID, long BSU_ID, long TRM_ID, string GRD_ID, long SBG_ID)
        {
            var result = await assessmentSettingService.GetReflectionSetupList(ACD_ID, BSU_ID, TRM_ID, GRD_ID, SBG_ID);
            return Ok(result);
        }
        #endregion

        #region Course Selection Setup
        [HttpPost]
        [Route("CourseSelectionPrerequisiteCu")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CourseSelectionPrerequisiteCu(CourseSelectionPrerequisite assessmentConfig)
        {
            var result = await assessmentSettingService.CourseSelectionPrerequisiteCu(assessmentConfig);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetCourseSelectionPrerequisite")]
        [ProducesResponseType(typeof(IEnumerable<CourseSelectionPrerequisite>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCourseSelectionPrerequisite(long subjectId, long acdId = 0, string grdId = "")
        {
            var result = await assessmentSettingService.GetCourseSelectionPrerequisite(subjectId, acdId, grdId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetValidationType")]
        [ProducesResponseType(typeof(IEnumerable<CouseSelectionValidationType>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetValidationType()
        {
            var result = await assessmentSettingService.GetValidationType();
            return Ok(result);
        }

        [HttpPost]
        [Route("CourseSelectionDetailsCUD")]
        [ProducesResponseType(typeof(IEnumerable<CourseSelectionDetailsCUDResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CourseSelectionDetailsCUD(CourseSelectionDetailsCUD courseSelection)
        {
            var result = await assessmentSettingService.CourseSelectionDetailsCUD(courseSelection);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSelectionSubjectCriterias")]
        [ProducesResponseType(typeof(IEnumerable<CouserSelectionSubjectCriteria>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSelectionSubjectCriterias(long ACD_ID, long BSU_ID, string GRD_ID, long STM_ID)
        {
            var result = await assessmentSettingService.GetSelectionSubjectCriterias(ACD_ID, BSU_ID, GRD_ID, STM_ID);
            return Ok(result);
        }

        [HttpPost]
        [Route("CourseSelectionStudentSubjectsCD")]
        [ProducesResponseType(typeof(List<CourseSelectedStudent>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CourseSelectionStudentSubjectsCD(List<CourseSelectedStudent> courseSelected)
        {
            var result = await assessmentSettingService.CourseSelectionStudentSubjectsCD(courseSelected);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetCourseSelectedStudents")]
        [ProducesResponseType(typeof(IEnumerable<CourseSelectedStudent>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCourseSelectedStudents(long userId, long schoolId, long academicYearId, long nextAcademicYearId)
        {
            var result = await assessmentSettingService.GetCourseSelectedStudents(userId, schoolId, academicYearId, nextAcademicYearId);
            return Ok(result);
        }
        #endregion
    }
}