using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface IAssessmentSettingService
    {
        #region  Other Configuration Setting

        #region Dhanaji Patil
        Task<AbsenteeSettingModel> GetAbsenteeSetting(long BSU_ID, long ACD_ID);
        Task<int> SaveAbsenteeSetting(AbsenteeSettingModel absenteeSettingModel);
        Task<IEnumerable<ReportDesignName>> GetReportDesignNameList(long BSU_ID, long ACD_ID);
        Task<IEnumerable<ReportDesignLink>> GetReportDesignLinkList(long BSU_ID, long ACD_ID);
        Task<int> SaveReportDesignLink(ReportDesignLink reportDesignLink, string DATAMODE);
        Task<IEnumerable<RuleSetupModel>> GetReportRuleList(long ACD_ID, string GRD_ID, long STM_ID, long SBG_ID, long TRM_ID, long RRM_ID);
        Task<int> SaveRuleSetup(RuleSetupModel ruleSetupModel);
        Task<IEnumerable<AssesmentWithType>> GetAssesmentWithTypeList(long ACD_ID, long TRM_ID);
        Task<IEnumerable<AssesmentWithType>> GetReportScheduleDetail(long RRM_ID);
        Task<int> DeleteAppliedReportRule(long RSS_ID);
        Task<IEnumerable<PublishedReportModel>> GePublishedReportList(long ACD_ID, string GRD_ID, long TRM_ID, long RSM_ID, long RPF_ID, int GRADE_ACCESS, string USERNAME);
        Task<int> SaveUnpublishedReport(UnpublishedReportData objUnpublishedReport, string userName);
        Task<IEnumerable<SubjectSpecificCriteria>> GetSubjectSpecificList(long RSM_ID, long SBG_ID);       
        Task<int> SaveSubjectSpecificCriteria(SubjectSpecificCriteriaData ObjSubjectSpecificCriteria);
        #endregion

        Task<IEnumerable<AssessmentDescriptor>> GetDefaultListById(long RDM_ID);
        bool OtherSettings_DefaultListCUD(long RDM_ID, long BSU_ID, string DEFAULT_DESCR, string DATAMODE, List<AssessmentDescriptor> objAssessmentDescriptor);

        Task<IEnumerable<SubjectCategoryModel>> GetSubjectCategory(long SBG_ID);
        Task<string> OtherSettings_SubjectCategoryCUD(SubjectCategoryModel SubjectCategoryModel);

        Task<int> SaveDefaultValues(DefaultValues defaultValues);
        Task<IEnumerable<DefaultValues>> GetDefaultValues(long RSM_ID);
        Task<CourseContent> GetCourseContent(CourseContentParameter courseContentParameter);
        Task<int> SaveCourseContent(CourseContent courseContent);
       
        #endregion

        #region Assessment Configuration
        Task<IEnumerable<AssessmentSettings>> GetAssessmentSettings(long AcdId, long schoolId, int divisionId);
        Task<AssessmentConfig> GetAssessmentConfigs(long rsmId, long AcdId, long schoolId);
        Task<string> AssessmentConfigCUD(AssessmentConfig assessmentConfig);
        #endregion

        #region Reflection Setup
        Task<IEnumerable<OutComeModel>> GetOutComeList(long ACD_ID, long BSU_ID, long TRM_ID, string GRD_ID, long SBG_ID);
        Task<int> SaveReflectionSetup(ReflectionSetupModel reflectionSetupModel, string DATAMODE);
        Task<IEnumerable<ReflectionSetupModel>> GetReflectionSetupList(long ACD_ID, long BSU_ID, long TRM_ID, string GRD_ID, long SBG_ID);
        #endregion

        #region Course Selection Setup
        Task<long> CourseSelectionPrerequisiteCu(CourseSelectionPrerequisite prerequisite);
        Task<IEnumerable<CourseSelectionPrerequisite>> GetCourseSelectionPrerequisite(long subjectId, long acdId, string grdId);
        Task<IEnumerable<CouseSelectionValidationType>> GetValidationType();
        Task<IEnumerable<CourseSelectionDetailsCUDResponse>> CourseSelectionDetailsCUD(CourseSelectionDetailsCUD courseSelection);
        Task<IEnumerable<CouserSelectionSubjectCriteria>> GetSelectionSubjectCriterias(long ACD_ID, long BSU_ID, string GRD_ID, long STM_ID);
        Task<bool> CourseSelectionStudentSubjectsCD(List<CourseSelectedStudent> courseSelected);
        Task<IEnumerable<CourseSelectedStudent>> GetCourseSelectedStudents(long userId, long schoolId, long academicYearId, long nextAcademicYearId);
        #endregion


    }
}
