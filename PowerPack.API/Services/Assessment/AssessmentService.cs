using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PowerPack.Common.Enums;
using PowerPack.Common.Models;

namespace SIMS.API.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IAssessmentRepository _AssessmentRepository;

        public AssessmentService(IAssessmentRepository AssessmentRepository)
        {
            _AssessmentRepository = AssessmentRepository;
        }
        public async Task<IEnumerable<StudentList>> GetStudentList(string GRD_ID, Int32 ACD_ID, Int32 SGR_ID, Int32 SCT_ID)
        {
            return await _AssessmentRepository.GetStudentList(GRD_ID, ACD_ID, SGR_ID, SCT_ID);
        }
        public async Task<IEnumerable<ReportHeader>> GetReportHeaders(string GRD_ID, Int32 ACD_ID, Int32 SBG_ID, Int32 RPF_ID, Int32 RSM_ID, string prv, ReportHeaderType IsGradeBook)
        {
            return await _AssessmentRepository.GetReportHeaders(GRD_ID, ACD_ID, SBG_ID, RPF_ID, RSM_ID, prv, IsGradeBook);
        }
        public async Task<IEnumerable<ReportHeaderDropDown>> GetReportHeadersDropdowns(Int32 RSM_ID, Int32 SBG_ID, Int32 RSD_ID)
        {
            return await _AssessmentRepository.GetReportHeadersDropdowns(RSM_ID, SBG_ID, RSD_ID);
        }
        public async Task<IEnumerable<AssessmentData>> GetAssessmentData(Int32 ACD_ID, Int32 SBG_ID, Int32 RPF_ID, Int32 RSM_ID, string prv)
        {
            return await _AssessmentRepository.GetAssessmentData(ACD_ID, SBG_ID, RPF_ID, RSM_ID, prv);
        }
        public async Task<int> InsertAssessmentData(string student_xml, string username, int bEdit)
        {
            return await _AssessmentRepository.InsertAssessmentData(student_xml, username, bEdit);
        }

        public async Task<IEnumerable<MarkEntry>> GetAssessmentActivityList(long ACD_ID = 0, long CAM_ID = 0, string GRD_ID = "", long STM_ID = 0, long TRM_ID = 0, long SGR_ID = 0, long SBG_ID = 0, int GRADE_ACCESS = 0, string Username = "", string SuperUser = "")
        {
            return await _AssessmentRepository.GetAssessmentActivityList(ACD_ID, CAM_ID, GRD_ID, STM_ID, TRM_ID, SGR_ID, SBG_ID, GRADE_ACCESS, Username, SuperUser);
        }
        public async Task<IEnumerable<MarkEntryData>> GetMarkEntryData(long CAS_ID, double MIN_MARK, double MAX_MARK)
        {
            return await _AssessmentRepository.GetMarkEntryData(CAS_ID, MIN_MARK, MAX_MARK);
        }
        public async Task<IEnumerable<MarkEntryAOLData>> GetMarkEntryAOLData(long CAS_ID)
        {
            return await _AssessmentRepository.GetMarkEntryAOLData(CAS_ID);
        }

        public bool InsertMarkEntryAOLData(List<MarkEntryAOLData> lstmarkEntryAOLData, string Username, bool bWithoutSkill, long CAS_ID)
        {
            return _AssessmentRepository.InsertMarkEntryAOLData(lstmarkEntryAOLData, Username, bWithoutSkill, CAS_ID);
        }

        public bool InsertMarkEntryData(List<MarkEntryData> lstmarkEntryData, long SlabId, string entryType, long CAS_ID)
        {
            return _AssessmentRepository.InsertMarkEntryData(lstmarkEntryData, SlabId, entryType, CAS_ID);
        }

        public async Task<IEnumerable<AssessmentComments>> GetAssessmentComments(int CAT_ID, long STU_ID)
        {
            return await _AssessmentRepository.GetAssessmentComments(CAT_ID, STU_ID);
        }
        public async Task<IEnumerable<GetHeaderBySubjectCategory>> GetHeaderBySubjectCategory(long SGRP_ID)
        {
            return await _AssessmentRepository.GetHeaderBySubjectCategory(SGRP_ID);
        }
        

        public async Task<IEnumerable<AssessmentCategory>> GetAssessmentCategories(long CAT_BSU_ID, string CAT_GRD_ID)
        {
            return await _AssessmentRepository.GetAssessmentCategories(CAT_BSU_ID, CAT_GRD_ID);
        }
        public async Task<IEnumerable<SectionAccess>> GetSectionAccess(string USERNAME, string IsSuperUser, long ACD_ID, long BSU_ID, int GRD_ACCESS, string GRD_ID)
        {
            return await _AssessmentRepository.GetSectionAccess(USERNAME, IsSuperUser, ACD_ID, BSU_ID, GRD_ACCESS, GRD_ID);
        }
        public async Task<IEnumerable<HeaderOptional>> GetReportHeaderOptional(string AOD_IDs)
        {
            return await _AssessmentRepository.GetReportHeaderOptional(AOD_IDs);
        }
        public async Task<IEnumerable<AssessmentDataOptional>> GetAssessmentDataOptional(long ACD_ID, long RPF_ID, long RSM_ID, long SBG_ID, long SGR_ID, string GRD_ID, long SCT_ID, string AOD_IDs)
        {
            return await _AssessmentRepository.GetAssessmentDataOptional(ACD_ID, RPF_ID, RSM_ID, SBG_ID, SGR_ID, GRD_ID, SCT_ID, AOD_IDs);
        }

        public async Task<IEnumerable<AssessmentPreviousSchedule>> GetAssessmentPreviousSchedule(long ACD_ID, string GRD_ID)
        {
            return await _AssessmentRepository.GetAssessmentPreviousSchedule(ACD_ID, GRD_ID);
        }

        public async Task<IEnumerable<AssessmentOptionalList>> GetAssessmentOptionList(long BSU_ID, long ACD_ID)
        {
            return await _AssessmentRepository.GetAssessmentOptionList(BSU_ID, ACD_ID);
        }
        public async Task<bool> IsReportPublish(long RPP_RSM_ID, long RPP_RPF_ID, long RPP_ACD_ID, string RPP_GRD_ID, long RPP_SCT_ID, long RPP_TRM_ID)
        {
            return await _AssessmentRepository.IsReportPublish(RPP_RSM_ID, RPP_RPF_ID, RPP_ACD_ID, RPP_GRD_ID, RPP_SCT_ID, RPP_TRM_ID);
        }

        public bool UpdateMarkAttendance(List<MarkAttendance> lstMarkAttendance, long CAS_ID)
        {
            return _AssessmentRepository.UpdateMarkAttendance(lstMarkAttendance, CAS_ID);
        }

        #region Grade Book Setup       
        public async Task<IEnumerable<GradeBookGradeScale>> GetGradeScaleList(long BSU_ID, long ACD_ID, long TEACHER_ID)
        {
            return await _AssessmentRepository.GetGradeScaleList(BSU_ID, ACD_ID, TEACHER_ID);
        }
        public async Task<IEnumerable<GradeBookGradeScaleDetail>> GetGradeScaleDetailList(long GSM_ID)
        {
            return await _AssessmentRepository.GetGradeScaleDetailList(GSM_ID);
        }
        public async Task<int> SaveGradeScaleAndDetail(GradeBookGradeScale gradeBookGradeScale, string DATAMODE)
        {
            return await _AssessmentRepository.SaveGradeScaleAndDetail(gradeBookGradeScale, DATAMODE);
        }
        public async Task<int> SaveGradeBookSetup(GradeBookSetup gradeBookSetup, string DATAMODE)
        {
            return await _AssessmentRepository.SaveGradeBookSetup(gradeBookSetup, DATAMODE);
        }
        public async Task<IEnumerable<GradeBookSetup>> GetGradeBookSetupList(GradeBookSetup gradeBookSetup)
        {
            return await _AssessmentRepository.GetGradeBookSetupList(gradeBookSetup);
        }
        public async Task<IEnumerable<ReportHeaderModel>> GetReportHeaderByRSMID(long RSM_ID)
        {
            return await _AssessmentRepository.GetReportHeaderByRSMID(RSM_ID);
        }

        public async Task<IEnumerable<ListItem>> GetReportHeaderDDLByRSMID(long RSM_ID)
        {
            return await _AssessmentRepository.GetReportHeaderDDLByRSMID(RSM_ID);
        }
        public async Task<int> SaveProcessingRuleSetup(ProcessingRuleSetup processingRuleSetup, string DATAMODE)
        {
            return await _AssessmentRepository.SaveProcessingRuleSetup(processingRuleSetup, DATAMODE);
        }
        public async Task<IEnumerable<ProcessingRuleSetup>> GetProcessingRuleSetupList(long PRS_RSD_ID)
        {
            return await _AssessmentRepository.GetProcessingRuleSetupList(PRS_RSD_ID);
        }
        public async Task<IEnumerable<GradeBookDetail>> GetGradebookDetail(long RSD_ID)
        {
            return await _AssessmentRepository.GetGradebookDetail(RSD_ID);
        }
        #endregion

        #region Grade Book Entry
        public async Task<int> GradebookCUD(GradeBookEntryListModel gradeBookEntry)
        {
            return await _AssessmentRepository.GradebookCUD(gradeBookEntry);
        }
        #endregion

        public async Task<IEnumerable<Subjects>> GetSubjectsForReportWriting(long acdId, long studentId, string IsSuperUser, long employeeId) =>
            await _AssessmentRepository.GetSubjectsForReportWriting(acdId, studentId, IsSuperUser, employeeId);
        public async Task<IEnumerable<StudentReportWriting>> GetSavedRecordsOfReportWriting(long rpfId, long studentId) =>
            await _AssessmentRepository.GetSavedRecordsOfReportWriting(rpfId, studentId);
        public async Task<bool> ReportWritingCU(List<AssessmentData> assessmentData) =>
            await _AssessmentRepository.ReportWritingCU(assessmentData);
    }
}
