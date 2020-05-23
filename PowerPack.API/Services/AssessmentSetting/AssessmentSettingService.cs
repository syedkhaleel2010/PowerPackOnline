using SIMS.API.Models;
using SIMS.API.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SIMS.API.Helpers;

namespace SIMS.API.Services
{
    public class AssessmentSettingService : IAssessmentSettingService
    {
        private readonly IAssessmentSettingRepository _AssessmentSettingRepository;
        public AssessmentSettingService(IAssessmentSettingRepository AssessmentSettingRepository)
        {
            _AssessmentSettingRepository = AssessmentSettingRepository;
        }

        #region  Other Configuration Setting

        #region Dhanaji Patil
        public async Task<AbsenteeSettingModel> GetAbsenteeSetting(long BSU_ID, long ACD_ID)
        {
            return await _AssessmentSettingRepository.GetAbsenteeSetting(BSU_ID, ACD_ID);
        }
        public async Task<int> SaveAbsenteeSetting(AbsenteeSettingModel absenteeSettingModel)
        {
            return await _AssessmentSettingRepository.SaveAbsenteeSetting(absenteeSettingModel);
        }
        public async Task<IEnumerable<ReportDesignName>> GetReportDesignNameList(long BSU_ID, long ACD_ID)
        {
            return await _AssessmentSettingRepository.GetReportDesignNameList(BSU_ID, ACD_ID);
        }
        public async Task<IEnumerable<ReportDesignLink>> GetReportDesignLinkList(long BSU_ID, long ACD_ID)
        {
            return await _AssessmentSettingRepository.GetReportDesignLinkList(BSU_ID, ACD_ID);
        }
        public async Task<int> SaveReportDesignLink(ReportDesignLink reportDesignLink, string DATAMODE)
        {
            return await _AssessmentSettingRepository.SaveReportDesignLink(reportDesignLink, DATAMODE);
        }
        public async Task<IEnumerable<RuleSetupModel>> GetReportRuleList(long ACD_ID, string GRD_ID, long STM_ID, long SBG_ID, long TRM_ID, long RRM_ID)
        {
            return await _AssessmentSettingRepository.GetReportRuleList(ACD_ID, GRD_ID, STM_ID, SBG_ID, TRM_ID, RRM_ID);
        }
        public async Task<int> SaveRuleSetup(RuleSetupModel ruleSetupModel)
        {
            return await _AssessmentSettingRepository.SaveRuleSetup(ruleSetupModel);
        }
        public async Task<IEnumerable<AssesmentWithType>> GetAssesmentWithTypeList(long ACD_ID, long TRM_ID)
        {
            return await _AssessmentSettingRepository.GetAssesmentWithTypeList(ACD_ID, TRM_ID);
        }
        public async Task<IEnumerable<AssesmentWithType>> GetReportScheduleDetail(long RRM_ID)
        {
            return await _AssessmentSettingRepository.GetReportScheduleDetail(RRM_ID);
        }
        public async Task<int> DeleteAppliedReportRule(long RSS_ID)
        {
            return await _AssessmentSettingRepository.DeleteAppliedReportRule(RSS_ID);
        }
        public async Task<IEnumerable<PublishedReportModel>> GePublishedReportList(long ACD_ID, string GRD_ID, long TRM_ID, long RSM_ID, long RPF_ID, int GRADE_ACCESS, string USERNAME)
        {
            return await _AssessmentSettingRepository.GePublishedReportList(ACD_ID, GRD_ID, TRM_ID, RSM_ID, RPF_ID, GRADE_ACCESS, USERNAME);
        }
        public async Task<int> SaveUnpublishedReport(UnpublishedReportData objUnpublishedReport, string userName)
        {
            return await _AssessmentSettingRepository.SaveUnpublishedReport(objUnpublishedReport, userName);
        }
        public async Task<IEnumerable<SubjectSpecificCriteria>> GetSubjectSpecificList(long RSM_ID, long SBG_ID)
        {
            return await _AssessmentSettingRepository.GetSubjectSpecificList(RSM_ID, SBG_ID);
        }
        public async Task<int> SaveSubjectSpecificCriteria(SubjectSpecificCriteriaData ObjSubjectSpecificCriteria)
        {
            return await _AssessmentSettingRepository.SaveSubjectSpecificCriteria(ObjSubjectSpecificCriteria);
        }
        #endregion

        public async Task<IEnumerable<AssessmentDescriptor>> GetDefaultListById(long RDM_ID)
        {
            return await _AssessmentSettingRepository.GetDefaultListById(RDM_ID);
        }


        public async Task<IEnumerable<SubjectCategoryModel>> GetSubjectCategory(long SBG_ID)
        {
            return await _AssessmentSettingRepository.GetSubjectCategory(SBG_ID);
        }
        public async Task<string> OtherSettings_SubjectCategoryCUD(SubjectCategoryModel SubjectCategoryModel)
        {
            return await _AssessmentSettingRepository.OtherSettings_SubjectCategoryCUD(SubjectCategoryModel);
        }

        public async Task<int> SaveDefaultValues(DefaultValues defaultValues)
        {
            return await _AssessmentSettingRepository.SaveDefaultValues(defaultValues);
        }

        public async Task<IEnumerable<DefaultValues>> GetDefaultValues(long RSM_ID)
        {
            return await _AssessmentSettingRepository.GetDefaultValues(RSM_ID);
        }

        public async Task<CourseContent> GetCourseContent(CourseContentParameter courseContentParameter)
        {
            return await _AssessmentSettingRepository.GetCourseContent(courseContentParameter);
        }

        public async Task<int> SaveCourseContent(CourseContent courseContent)
        {
            return await _AssessmentSettingRepository.SaveCourseContent(courseContent);
        }
        #endregion

        #region Assessment Configuration
        public async Task<IEnumerable<AssessmentSettings>> GetAssessmentSettings(long AcdId, long schoolId, int divisionId)
        {
            return await _AssessmentSettingRepository.GetAssessmentSettings(AcdId, schoolId, divisionId);
        }
        public async Task<AssessmentConfig> GetAssessmentConfigs(long rsmId, long AcdId, long schoolId)
        {
            return await _AssessmentSettingRepository.GetAssessmentConfigs(rsmId, AcdId, schoolId);
        }
        public async Task<string> AssessmentConfigCUD(AssessmentConfig assessmentConfig)
        {
            return await _AssessmentSettingRepository.AssessmentConfigCUD(assessmentConfig);
        }
        #endregion

        #region Reflection Setup
        public async Task<IEnumerable<OutComeModel>> GetOutComeList(long ACD_ID, long BSU_ID, long TRM_ID, string GRD_ID, long SBG_ID)
        {
            return await _AssessmentSettingRepository.GetOutComeList(ACD_ID, BSU_ID, TRM_ID, GRD_ID, SBG_ID);
        }
        public async Task<int> SaveReflectionSetup(ReflectionSetupModel reflectionSetupModel, string DATAMODE)
        {
            return await _AssessmentSettingRepository.SaveReflectionSetup(reflectionSetupModel, DATAMODE);
        }
        public async Task<IEnumerable<ReflectionSetupModel>> GetReflectionSetupList(long ACD_ID, long BSU_ID, long TRM_ID, string GRD_ID, long SBG_ID)
        {
            return await _AssessmentSettingRepository.GetReflectionSetupList(ACD_ID, BSU_ID, TRM_ID, GRD_ID, SBG_ID);
        }



        public bool OtherSettings_DefaultListCUD(long RDM_ID, long BSU_ID, string DEFAULT_DESCR, string DATAMODE, List<AssessmentDescriptor> objAssessmentDescriptor)
        {
            return _AssessmentSettingRepository.OtherSettings_DefaultListCUD(RDM_ID, BSU_ID, DEFAULT_DESCR, DATAMODE, objAssessmentDescriptor);
        }
        #endregion

        #region Course Selection Setup
        public async Task<long> CourseSelectionPrerequisiteCu(CourseSelectionPrerequisite prerequisite)
        {
            return await _AssessmentSettingRepository.CourseSelectionPrerequisiteCu(prerequisite);
        }

        public async Task<IEnumerable<CourseSelectionPrerequisite>> GetCourseSelectionPrerequisite(long subjectId, long acdId, string grdId)
        {
            return await _AssessmentSettingRepository.GetCourseSelectionPrerequisite(subjectId, acdId, grdId);
        }

        public async Task<IEnumerable<CouseSelectionValidationType>> GetValidationType()
        {
            return await _AssessmentSettingRepository.GetValidationType();
        }

        public async Task<IEnumerable<CourseSelectionDetailsCUDResponse>> CourseSelectionDetailsCUD(CourseSelectionDetailsCUD courseSelection)
        {
            return await _AssessmentSettingRepository.CourseSelectionDetailsCUD(courseSelection);
        }

        public async Task<IEnumerable<CouserSelectionSubjectCriteria>> GetSelectionSubjectCriterias(long ACD_ID, long BSU_ID, string GRD_ID, long STM_ID)
        {
            return await _AssessmentSettingRepository.GetSelectionSubjectCriterias(ACD_ID, BSU_ID, GRD_ID, STM_ID);
        }
        public async Task<bool> CourseSelectionStudentSubjectsCD(List<CourseSelectedStudent> courseSelected) =>
            await _AssessmentSettingRepository.CourseSelectionStudentSubjectsCD(courseSelected);

        public async Task<IEnumerable<CourseSelectedStudent>> GetCourseSelectedStudents(long userId, long schoolId, long academicYearId, long nextAcademicYearId) =>
            await _AssessmentSettingRepository.GetCourseSelectedStudents(userId, schoolId, academicYearId, nextAcademicYearId);
        #endregion
    }
}
