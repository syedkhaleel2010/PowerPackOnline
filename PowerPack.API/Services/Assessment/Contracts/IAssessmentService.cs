using PowerPack.Common.Models;
using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerPack.Common.Enums;

namespace SIMS.API.Services
{
    public interface IAssessmentService
    {
        Task<IEnumerable<StudentList>> GetStudentList(string GRD_ID, Int32 ACD_ID, Int32 SGR_ID, Int32 SCT_ID);
        Task<IEnumerable<ReportHeader>> GetReportHeaders(string GRD_ID, Int32 ACD_ID, Int32 SBG_ID, Int32 RPF_ID, Int32 RSM_ID, string prv, ReportHeaderType IsGradeBook);
        Task<IEnumerable<ReportHeaderDropDown>> GetReportHeadersDropdowns(Int32 RSM_ID, Int32 SBG_ID, Int32 RSD_ID);
        Task<IEnumerable<AssessmentData>> GetAssessmentData(Int32 ACD_ID, Int32 SBG_ID, Int32 RPF_ID, Int32 RSM_ID, string prv);
        Task<int> InsertAssessmentData(string student_xml, string username, int bEdit);
        Task<IEnumerable<MarkEntry>> GetAssessmentActivityList(long ACD_ID = 0, long CAM_ID = 0, string GRD_ID = "", long STM_ID = 0, long TRM_ID = 0, long SGR_ID = 0, long SBG_ID = 0, int GRADE_ACCESS = 0, string Username = "", string SuperUser = "");
        Task<IEnumerable<MarkEntryData>> GetMarkEntryData(long CAS_ID, double MIN_MARK, double MAX_MARK);
        Task<IEnumerable<MarkEntryAOLData>> GetMarkEntryAOLData(long CAS_ID);

        bool InsertMarkEntryAOLData(List<MarkEntryAOLData> lstmarkEntryAOLData, string Username, bool bWithoutSkill, long CAS_ID);
        bool InsertMarkEntryData(List<MarkEntryData> lstmarkEntryData, long SlabId, string entryType, long CAS_ID);

        Task<IEnumerable<AssessmentComments>> GetAssessmentComments(int CAT_ID, long STU_ID);
        Task<IEnumerable<GetHeaderBySubjectCategory>> GetHeaderBySubjectCategory(long SGRP_ID);
        
        Task<IEnumerable<AssessmentCategory>> GetAssessmentCategories(long CAT_BSU_ID, string CAT_GRD_ID);
        Task<IEnumerable<SectionAccess>> GetSectionAccess(string USERNAME, string IsSuperUser, long ACD_ID, long BSU_ID, int GRD_ACCESS, string GRD_ID);
        Task<IEnumerable<HeaderOptional>> GetReportHeaderOptional(string AOD_IDs);
        Task<IEnumerable<AssessmentDataOptional>> GetAssessmentDataOptional(long ACD_ID, long RPF_ID, long RSM_ID, long SBG_ID, long SGR_ID, string GRD_ID, long SCT_ID, string AOD_IDs);
        Task<IEnumerable<AssessmentPreviousSchedule>> GetAssessmentPreviousSchedule(long ACD_ID, string GRD_ID);
        Task<IEnumerable<AssessmentOptionalList>> GetAssessmentOptionList(long BSU_ID, long ACD_ID);
        Task<bool> IsReportPublish(long RPP_RSM_ID, long RPP_RPF_ID, long RPP_ACD_ID, string RPP_GRD_ID, long RPP_SCT_ID, long RPP_TRM_ID);

        bool UpdateMarkAttendance(List<MarkAttendance> lstMarkAttendance, long CAS_ID);

        #region Grade Book Setup
        Task<IEnumerable<GradeBookGradeScale>> GetGradeScaleList(long BSU_ID, long ACD_ID, long TEACHER_ID);
        Task<IEnumerable<GradeBookGradeScaleDetail>> GetGradeScaleDetailList(long GSM_ID);
        Task<int> SaveGradeScaleAndDetail(GradeBookGradeScale gradeBookGradeScale, string DATAMODE);
        Task<int> SaveGradeBookSetup(GradeBookSetup gradeBookSetup, string DATAMODE);
        Task<IEnumerable<GradeBookSetup>> GetGradeBookSetupList(GradeBookSetup gradeBookSetup);
        Task<IEnumerable<ReportHeaderModel>> GetReportHeaderByRSMID(long RSM_ID);
        Task<IEnumerable<ListItem>> GetReportHeaderDDLByRSMID(long RSM_ID);
        Task<int> SaveProcessingRuleSetup(ProcessingRuleSetup processingRuleSetup, string DATAMODE);
        Task<IEnumerable<ProcessingRuleSetup>> GetProcessingRuleSetupList(long PRS_RSD_ID);
        Task<IEnumerable<GradeBookDetail>> GetGradebookDetail(long RSD_ID);
        #endregion

        #region Grade Book Entry
        Task<int> GradebookCUD(GradeBookEntryListModel gradeBookEntry);
        #endregion

        Task<IEnumerable<Subjects>> GetSubjectsForReportWriting(long acdId, long studentId, string IsSuperUser, long employeeId);
        Task<IEnumerable<StudentReportWriting>> GetSavedRecordsOfReportWriting(long rpfId, long studentId);
        Task<bool> ReportWritingCU(List<AssessmentData> assessmentData);
    }
}
