using DbConnection;
using PowerPack.Common.Enums;
using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Repositories
{
    public interface ISubjectSettingRepository
    {
        #region Made By Dhanaji
        Task<IEnumerable<SubjectMaster>> GetSubjectMasterList(int CLM_ID);
        Task<int> SubjectMasterCUD(SubjectMaster subjectMaster, string mode);
        Task<IEnumerable<ShiftModel>> GetShiftListById(long ACD_ID, string GRD_ID);
        Task<IEnumerable<SubjectGroup>> GetSubjectGroupList(long ACD_ID, string IsSuperUser, string Username, bool IsOptional, int divisionId);
        Task<IEnumerable<SubjectMaster>> GetSubjectMastersByCurriculum(long curriculumId);
        Task<IEnumerable<SubjectGroupTeacherDdl>> GetSubjectGroupTeachers(long BSU_ID, string IsSuperUser, string Username);
        Task<IEnumerable<SubjectGroupTeacher>> GetSubjectGroupTeachersGrid(long SGR_ID, string IsSuperUser, string Username);
        Task<int> SaveUpdateGroupTeacher(SubjectGroup subjectGroupTeacher, string UserName, string mode);
        Task<int> SaveUpdateSubjectGroup(SubjectGroup subjectGroup, string mode);
        Task SubjectGroupStudentAssign(SubjectGroup subjectGroup, long SchoolId, string mode);
        Task<IEnumerable<SubjectGroupStudent>> GetSubjectGroupStudentList(long ACD_ID, string GRD_ID, int SHF_ID, int STM_ID, long SBG_ID, long SGR_ID);
        Task<IEnumerable<SubjectGroupDdl>> GetSubjectGroupDdl(long ACD_ID, string GRD_ID, int SHF_ID, int STM_ID, long SBG_ID, long EMP_ID);
        Task<IEnumerable<BindMandatorySubject>> BindMandatorySubject(long ACD_ID, string GRD_ID);
        Task<IEnumerable<BindOptionalSubject>> BindOptionalSubject(long ACD_ID, string GRD_ID);
        Task<int> SaveChangeGroupData(DataTable dt);
        Task<IEnumerable<SelectedOptionByStudent>> GetSelectedOptionListByStudent(long ACD_ID, long STU_ID);
        Task<int> ChangeSelectedStudentGroup(ChangeSelectedStudentGroup changeSelectedStudentGroup);
        Task<int> BulkUploadObjective(UploadObjectiveModel uploadObjectiveModel, DataTable dt);
        Task<IEnumerable<TopicDetail>> GetTopicDetailList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID, long SYD_ID);
        Task<IEnumerable<TopicObjective>> GetTopicObjectiveList(long SYD_ID);
        Task<IEnumerable<TopicParent>> GetTopicParentList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID);
        Task<int> AddEditTopicDetails(TopicDetail topicDetail, string DATAMODE);
        Task<int> AddEditTopicObjective(TopicObjective topicObjective, string DATAMODE);
        #endregion

        Task<IEnumerable<SubjectByGradeParent>> BindGradesForSubject(long ACD_ID, int divisionId);
        Task<IEnumerable<SubjectByGradeChild>> BindSubjectsByGrade(long ACD_ID, string GRD_ID, int STM_ID, int SBG_ID);
        Task<IEnumerable<ParentSubject>> GetParentSubjects(long ACD_ID, int STM_ID, string GRD_ID);
        Task<IEnumerable<SubjectByGradeParent>> GetGradeForSubjectCopy(long ACD_ID);
        Task<IEnumerable<FromStream>> GetStreamForSubjectCopy(long ACD_ID, string GRD_ID);
        Task<int> AddOptionName(long schoolId, string optionName);
        Task<string> SubjectGrade(DataTable dt, string mode);
    }
}
