using Microsoft.AspNetCore.Mvc;
using SIMS.API.Services;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Xml.Linq;
using PowerPack.Common.Enums;
using System.Data;

namespace SIMS.API.Areas.SubjectSetting.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubjectSettingController : ControllerBase
    {
        private readonly ISubjectSettingService _SubjectSettingService;
        private const string Add = "ADD";
        private const string Edit = "EDIT";
        private const string Delete = "DELETE";

        public SubjectSettingController(ISubjectSettingService SubjectSettingService)
        {
            _SubjectSettingService = SubjectSettingService;

        }

        #region Made By Dhanaji

        #region Subject Master

        [HttpGet]
        [Route("GetSubjectMasterList")]
        [ProducesResponseType(typeof(IEnumerable<SubjectMaster>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubjectMasterList(int CLM_ID)
        {
            var result = await _SubjectSettingService.GetSubjectMasterList(CLM_ID);
            return Ok(result);
        }

        [HttpPost]
        [Route("SubjectMasterCUD")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SubjectMasterCUD(string mode, SubjectMaster subjectMaster)
        {
            var result = await _SubjectSettingService.SubjectMasterCUD(subjectMaster, mode);
            return Ok(result);
        }

        #endregion

        #region Subject Group

        [HttpGet]
        [Route("GetSubjectGroupList")]
        [ProducesResponseType(typeof(IEnumerable<SubjectGroup>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubjectGroupList(long ACD_ID, string IsSuperUser, string Username, bool IsOptional, int divisionId)
        {
            var result = await _SubjectSettingService.GetSubjectGroupList(ACD_ID, IsSuperUser, Username, IsOptional,divisionId);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetShiftListById")]
        [ProducesResponseType(typeof(IEnumerable<ShiftModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetShiftListById(long ACD_ID, string GRD_ID)
        {
            var result = await _SubjectSettingService.GetShiftListById(ACD_ID, GRD_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSubjectGroupTeachers")]
        [ProducesResponseType(typeof(IEnumerable<SubjectGroupTeacherDdl>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubjectGroupTeachers(long BSU_ID, string IsSuperUser, string Username)
        {
            var result = await _SubjectSettingService.GetSubjectGroupTeachers(BSU_ID, IsSuperUser, Username);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetSubjectGroupTeachersGrid")]
        [ProducesResponseType(typeof(IEnumerable<SubjectGroupTeacher>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubjectGroupTeachersGrid(long SGR_ID, string IsSuperUser, string Username)
        {
            var result = await _SubjectSettingService.GetSubjectGroupTeachersGrid(SGR_ID, IsSuperUser, Username);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveUpdateGroupTeacher")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveUpdateGroupTeacher(SubjectGroup subjectGroupTeacher, string UserName, string mode)
        {
            var result = await _SubjectSettingService.SaveUpdateGroupTeacher(subjectGroupTeacher, UserName, mode);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveUpdateSubjectGroup")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveUpdateSubjectGroup(SubjectGroup subjectGroupTeacher, string mode)
        {
            var result = await _SubjectSettingService.SaveUpdateSubjectGroup(subjectGroupTeacher, mode);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetSubjectGroupStudentList")]
        [ProducesResponseType(typeof(IEnumerable<SubjectGroupStudent>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubjectGroupStudentList(long ACD_ID, string GRD_ID, int SHF_ID, int STM_ID, long SBG_ID, long SGR_ID)
        {
            var result = await _SubjectSettingService.GetSubjectGroupStudentList(ACD_ID, GRD_ID, SHF_ID, STM_ID, SBG_ID, SGR_ID);
            return Ok(result);
        }
        #endregion

        #region Change Group
        [HttpGet]
        [Route("GetSubjectGroupDdl")]
        [ProducesResponseType(typeof(IEnumerable<SubjectGroupDdl>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubjectGroupDdl(long ACD_ID, string GRD_ID, int SHF_ID, int STM_ID, long SBG_ID, long EMP_ID)
        {
            var result = await _SubjectSettingService.GetSubjectGroupDdl(ACD_ID, GRD_ID, SHF_ID, STM_ID, SBG_ID, EMP_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("BindMandatorySubject")]
        [ProducesResponseType(typeof(IEnumerable<BindMandatorySubject>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindMandatorySubject(long ACD_ID, string GRD_ID)
        {
            var result = await _SubjectSettingService.BindMandatorySubject(ACD_ID, GRD_ID);
            return Ok(result);
        }
        [HttpGet]
        [Route("BindOptionalSubject")]
        [ProducesResponseType(typeof(IEnumerable<BindOptionalSubject>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindOptionalSubject(long ACD_ID, string GRD_ID)
        {
            var result = await _SubjectSettingService.BindOptionalSubject(ACD_ID, GRD_ID);
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveChangeGroupData")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> SaveChangeGroupData(List<ChangeGroupData> _ChangeGroupData)
        {
            var result = await _SubjectSettingService.SaveChangeGroupData(_ChangeGroupData);
            return Ok(result);
        }
        [HttpPost]
        [Route("ChangeSelectedStudentGroup")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> ChangeSelectedStudentGroup(ChangeSelectedStudentGroup changeSelectedStudentGroup)
        {
            var result = await _SubjectSettingService.ChangeSelectedStudentGroup(changeSelectedStudentGroup);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetSelectedOptionListByStudent")]
        [ProducesResponseType(typeof(IEnumerable<SelectedOptionByStudent>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSelectedOptionListByStudent(long ACD_ID, long STU_ID)
        {
            var result = await _SubjectSettingService.GetSelectedOptionListByStudent(ACD_ID, STU_ID);
            return Ok(result);
        }
        #endregion

        #endregion

        #region SubjectByGrade

        [HttpGet]
        [Route("BindGradesForSubject")]
        [ProducesResponseType(typeof(IEnumerable<SubjectByGradeParent>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindGradesForSubject(long ACD_ID, int divisionId)
        {
            var result = await _SubjectSettingService.BindGradesForSubject(ACD_ID, divisionId);
            return Ok(result);
        }

        [HttpGet]
        [Route("BindSubjectsByGrade")]
        [ProducesResponseType(typeof(IEnumerable<SubjectByGradeChild>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BindSubjectsByGrade(long ACD_ID, string GRD_ID, int STM_ID, int SBG_ID = 0)
        {
            var result = await _SubjectSettingService.BindSubjectsByGrade(ACD_ID, GRD_ID, STM_ID, SBG_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSubjectMastersByCurriculum")]
        [ProducesResponseType(typeof(IEnumerable<SubjectByGradeChild>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSubjectMastersByCurriculum(long curriculumId)
        {
            var result = await _SubjectSettingService.GetSubjectMastersByCurriculum(curriculumId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetParentSubjects")]
        [ProducesResponseType(typeof(IEnumerable<SubjectByGradeChild>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetParentSubjects(long ACD_ID, int STM_ID, string GRD_ID)
        {
            var result = await _SubjectSettingService.GetParentSubjects(ACD_ID, STM_ID, GRD_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetGradeForSubjectCopy")]
        [ProducesResponseType(typeof(IEnumerable<SubjectByGradeChild>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGradeForSubjectCopy(long ACD_ID)
        {
            var result = await _SubjectSettingService.GetGradeForSubjectCopy(ACD_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetStreamForSubjectCopy")]
        [ProducesResponseType(typeof(IEnumerable<SubjectByGradeChild>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStreamForSubjectCopy(long ACD_ID, string GRD_ID)
        {
            var result = await _SubjectSettingService.GetStreamForSubjectCopy(ACD_ID, GRD_ID);
            return Ok(result);
        }

        [HttpGet]
        [Route("AddOptionName")]
        [ProducesResponseType(typeof(IEnumerable<SubjectByGradeChild>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddOptionName(long schoolId, string OptionName)
        {
            var result = await _SubjectSettingService.AddOptionName(schoolId, OptionName);
            return Ok(result);
        }

        [HttpPost]
        [Route("SubjectGrade")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> SubjectGradeCU(List<SubjectByGradeEntry> source)
        {
            bool isNew = source.Count > 1 || source.Exists(x => x.SubjectGradeId == null);
            DataTable dt = _SubjectSettingService.CreateDataTable();
            foreach (SubjectByGradeEntry item in source)
            {
                DataRow dr = dt.NewRow();
                if (item.SubjectGradeId != null)
                    dr["SBG_ID"] = item.SubjectGradeId;
                else
                    dr["SBG_ID"] = DBNull.Value;
                dr["SBG_ACD_ID"] = item.ACD_ID;
                dr["SBG_BSU_ID"] = item.BSU_ID;
                dr["SBG_GRD_ID"] = item.GRD_ID;
                dr["SBG_STM_ID"] = item.STM_ID;
                dr["SBG_SBM_ID"] = item.SubjectId;
                dr["SBG_DESCR"] = item.Description;
                dr["SBG_SHORTCODE"] = item.ShortCode;
                dr["SBG_DPT_ID"] = item.DepartmentId;
                dr["SBG_bOPTIONAL"] = item.b_MarkAsOptional;
                dr["OPT_XML"] = item.OptionNamesXML;
                dr["SBG_PARENT_ID"] = item.ParentSubject == null ? "0" : item.ParentSubject;
                dr["SBG_bREPCRD_DISPLAY"] = item.b_DisplaySubjectInReportCard;
                dr["SBG_bMRK_DISPLAY"] = item.b_DisplayMarksInReportCard;
                dr["SBG_ORDER"] = item.DisplayOrder;
                dr["SBG_bTC_DISPLAY"] = item.b_DisplaySubjectInTC;
                dr["SBG_OPTIONS"] = item.OptionNamesJoin;
                dr["SBG_PARENTS"] = item.ParentSubjectDescription;
                dr["SBG_PARENTS_SHORT"] = item.ParentSubjectDescription;
                dr["SBG_bCOREEXT"] = item.b_IsCor;
                dr["SBG_bAUTOGROUP"] = item.AutoGroup;
                dr["SBG_bMAJOR"] = item.SubjectType;

                dr["SBG_CREDITS"] = item.Credits;
                dr["SBG_WT"] = item.WT;
                dr["SBG_LEN"] = item.LENG;
                dr["SBG_HRS"] = item.HRS;
                dr["SBG_GPA"] = item.GPA;
                if (item.MinimumMarks != null)
                    dr["SBG_MINMARK"] = item.MinimumMarks;
                else
                    dr["SBG_MINMARK"] = DBNull.Value;
                dr["SBG_bRETEST"] = item.b_Retest;
                dr["SBG_bBROWNBOOKDISPLAY"] = item.b_DisplayInExcel;
                dr["SBG_bBTEC"] = item.b_BtecSubject;
                dr["SBG_ENTRYTYPE"] = Convert.ToBoolean(item.b_EnterMarks) ? "Mark" : "Grade";
                dr["SBG_Level"] = item.SBG_Level ? "SL" : "HL";
                dr["SBG_bATT_CALCULATION"] = item.SBG_bATT_CALCULATION;
                dr["SBG_bTRANSCRIPT"] = item.SBG_bTRANSCRIPT;
                dr["SBG_bREPORTCARD"] = item.SBG_bREPORTCARD;
                dr["SBG_bGPA"] = item.SBG_bGPA;
                dr["SBG_bHonorRoll"] = item.SBG_bHonorRoll;
                dr["SBG_CREDIT_VALUE"] = item.SBG_CREDIT_VALUE;
                dr["SBG_CREDIT_TYPE"] = item.SBG_CREDIT_TYPE;
                dt.Rows.Add(dr);
            }
            var result = await _SubjectSettingService.SubjectGrade(dt, isNew ? Add : Edit);
            return Ok(result);
        }

        [HttpGet]
        [Route("SubjectGradeD")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> SubjectGradeD(int subjectGradeId)
        {
            DataTable dt = _SubjectSettingService.CreateDataTable();
            DataRow dr = dt.NewRow();
            dr["SBG_ID"] = subjectGradeId;
            dt.Rows.Add(dr);
            var result = await _SubjectSettingService.SubjectGrade(dt, Delete);
            return Ok(result);
        }
        #endregion

    }
}