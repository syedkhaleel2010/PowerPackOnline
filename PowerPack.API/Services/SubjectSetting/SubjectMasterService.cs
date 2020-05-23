using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using PowerPack.Common.Enums;
using SIMS.API.Models;
using SIMS.API.Repositories;

namespace SIMS.API.Services
{
    public class SubjectSettingService : ISubjectSettingService
    {
        private readonly ISubjectSettingRepository _SubjectSettingRepository;

        public SubjectSettingService(ISubjectSettingRepository SubjectSettingRepository)
        {
            _SubjectSettingRepository = SubjectSettingRepository;
        }

        public async Task<IEnumerable<SubjectByGradeParent>> BindGradesForSubject(long ACD_ID, int divisionId)
        {
            return await _SubjectSettingRepository.BindGradesForSubject(ACD_ID,divisionId);
        }

        public async Task<IEnumerable<SubjectByGradeChild>> BindSubjectsByGrade(long ACD_ID, string GRD_ID, int STM_ID, int SBG_ID)
        {
            return await _SubjectSettingRepository.BindSubjectsByGrade(ACD_ID, GRD_ID, STM_ID, SBG_ID);
        }

        public async Task<IEnumerable<SubjectByGradeParent>> GetGradeForSubjectCopy(long ACD_ID)
        {
            return await _SubjectSettingRepository.GetGradeForSubjectCopy(ACD_ID);
        }

        public async Task<IEnumerable<ParentSubject>> GetParentSubjects(long ACD_ID, int STM_ID, string GRD_ID)
        {
            return await _SubjectSettingRepository.GetParentSubjects(ACD_ID, STM_ID, GRD_ID);
        }

        public async Task<IEnumerable<FromStream>> GetStreamForSubjectCopy(long ACD_ID, string GRD_ID)
        {
            return await _SubjectSettingRepository.GetStreamForSubjectCopy(ACD_ID, GRD_ID);
        }
        public async Task<int> AddOptionName(long schoolId, string optionName)
        {
            return await _SubjectSettingRepository.AddOptionName(schoolId, optionName);
        }

        public async Task<string> SubjectGrade(DataTable dt, string mode)
        {
            return await _SubjectSettingRepository.SubjectGrade(dt, mode);
        }

        public DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SBG_ID", typeof(long)));
            dt.Columns.Add(new DataColumn("SBG_ACD_ID", typeof(long)));
            dt.Columns.Add(new DataColumn("SBG_BSU_ID", typeof(long)));
            dt.Columns.Add(new DataColumn("SBG_GRD_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("SBG_STM_ID", typeof(int)));
            dt.Columns.Add(new DataColumn("SBG_SBM_ID", typeof(int)));
            dt.Columns.Add(new DataColumn("SBG_DESCR", typeof(string)));
            dt.Columns.Add(new DataColumn("SBG_SHORTCODE", typeof(string)));
            dt.Columns.Add(new DataColumn("SBG_DPT_ID", typeof(int)));
            dt.Columns.Add(new DataColumn("SBG_bOPTIONAL", typeof(bool)));
            dt.Columns.Add(new DataColumn("OPT_XML", typeof(string)));
            dt.Columns.Add(new DataColumn("SBG_PARENT_ID", typeof(int)));
            dt.Columns.Add(new DataColumn("SBG_bREPCRD_DISPLAY", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_bMRK_DISPLAY", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_ORDER", typeof(int)));
            dt.Columns.Add(new DataColumn("SBG_bTC_DISPLAY", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_OPTIONS", typeof(string)));
            dt.Columns.Add(new DataColumn("SBG_PARENTS", typeof(string)));
            dt.Columns.Add(new DataColumn("SBG_PARENTS_SHORT", typeof(string)));
            dt.Columns.Add(new DataColumn("SBG_bCOREEXT", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_bAUTOGROUP", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_bMAJOR", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_ENTRYTYPE", typeof(string)));
            dt.Columns.Add(new DataColumn("SBG_CREDITS", typeof(double)));
            dt.Columns.Add(new DataColumn("SBG_WT", typeof(double)));
            dt.Columns.Add(new DataColumn("SBG_LEN", typeof(string)));
            dt.Columns.Add(new DataColumn("SBG_HRS", typeof(string)));
            dt.Columns.Add(new DataColumn("SBG_GPA", typeof(string)));
            dt.Columns.Add(new DataColumn("SBG_MINMARK", typeof(double)));
            dt.Columns.Add(new DataColumn("SBG_bRETEST", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_bBROWNBOOKDISPLAY", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_bBTEC", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_Level", typeof(string)));

            dt.Columns.Add(new DataColumn("SBG_bATT_CALCULATION", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_bTRANSCRIPT", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_bREPORTCARD", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_bGPA", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_bHonorRoll", typeof(bool)));
            dt.Columns.Add(new DataColumn("SBG_CREDIT_VALUE", typeof(int)));
            dt.Columns.Add(new DataColumn("SBG_CREDIT_TYPE", typeof(string))); 
            foreach (DataColumn dc in dt.Columns)
            {
                dc.DefaultValue = DBNull.Value;
            }
            return dt;
        }

        #region Made By Dhanaji

        #region Subject Master
        public async Task<IEnumerable<SubjectMaster>> GetSubjectMasterList(int CLM_ID)
        {
            return await _SubjectSettingRepository.GetSubjectMasterList(CLM_ID);
        }
        public async Task<IEnumerable<SubjectMaster>> GetSubjectMastersByCurriculum(long curriculumId)
        {
            return await _SubjectSettingRepository.GetSubjectMastersByCurriculum(curriculumId);
        }
        public async Task<int> SubjectMasterCUD(SubjectMaster subjectMaster, string mode)
        {
            return await _SubjectSettingRepository.SubjectMasterCUD(subjectMaster, mode);
        }
        #endregion

        #region Subject Group
        public async Task<IEnumerable<SubjectGroup>> GetSubjectGroupList(long ACD_ID, string IsSuperUser, string Username, bool IsOptional, int divisionId)
        {
            return await _SubjectSettingRepository.GetSubjectGroupList(ACD_ID, IsSuperUser, Username, IsOptional,divisionId);
        }
        public async Task<IEnumerable<ShiftModel>> GetShiftListById(long ACD_ID, string GRD_ID)
        {
            return await _SubjectSettingRepository.GetShiftListById(ACD_ID, GRD_ID);
        }
        public async Task<IEnumerable<SubjectGroupTeacherDdl>> GetSubjectGroupTeachers(long BSU_ID, string IsSuperUser, string Username)
        {
            return await _SubjectSettingRepository.GetSubjectGroupTeachers(BSU_ID, IsSuperUser, Username);
        }
        public async Task<IEnumerable<SubjectGroupTeacher>> GetSubjectGroupTeachersGrid(long SGR_ID, string IsSuperUser, string Username)
        {
            return await _SubjectSettingRepository.GetSubjectGroupTeachersGrid(SGR_ID, IsSuperUser, Username);
        }
        public async Task<int> SaveUpdateGroupTeacher(SubjectGroup subjectGroupTeacher, string UserName, string mode)
        {
            return await _SubjectSettingRepository.SaveUpdateGroupTeacher(subjectGroupTeacher, UserName, mode);
        }
        public async Task<int> SaveUpdateSubjectGroup(SubjectGroup subjectGroup, string mode)
        {
            return await _SubjectSettingRepository.SaveUpdateSubjectGroup(subjectGroup, mode);
        }
        public async Task<IEnumerable<SubjectGroupStudent>> GetSubjectGroupStudentList(long ACD_ID, string GRD_ID, int SHF_ID, int STM_ID, long SBG_ID, long SGR_ID)
        {
            return await _SubjectSettingRepository.GetSubjectGroupStudentList(ACD_ID, GRD_ID, SHF_ID, STM_ID, SBG_ID, SGR_ID);
        }
        #endregion

        #region Change Group
        public async Task<IEnumerable<SubjectGroupDdl>> GetSubjectGroupDdl(long ACD_ID, string GRD_ID, int SHF_ID, int STM_ID, long SBG_ID, long EMP_ID)
        {
            return await _SubjectSettingRepository.GetSubjectGroupDdl(ACD_ID, GRD_ID, SHF_ID, STM_ID, SBG_ID, EMP_ID);
        }
        public async Task<IEnumerable<BindMandatorySubject>> BindMandatorySubject(long ACD_ID, string GRD_ID)
        {
            return await _SubjectSettingRepository.BindMandatorySubject(ACD_ID, GRD_ID);
        }
        public async Task<IEnumerable<BindOptionalSubject>> BindOptionalSubject(long ACD_ID, string GRD_ID)
        {
            return await _SubjectSettingRepository.BindOptionalSubject(ACD_ID, GRD_ID);
        }
        public async Task<int> SaveChangeGroupData(List<ChangeGroupData> _ChangeGroupData)
        {
            DataTable dt;
            dt = ConvertListToTable(_ChangeGroupData);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return await _SubjectSettingRepository.SaveChangeGroupData(dt);
        }
        public DataTable ConvertListToTable(List<ChangeGroupData> _ChangeGroupData)
        {
            DataTable listTable = new DataTable();
            listTable.Columns.Add("SSD_ACD_ID", System.Type.GetType("System.Int64"));
            listTable.Columns.Add("SSD_GRD_ID", System.Type.GetType("System.String"));
            listTable.Columns.Add("SSD_SBG_ID", System.Type.GetType("System.Int64"));
            listTable.Columns.Add("SSD_SGR_ID", System.Type.GetType("System.Int64"));
            listTable.Columns.Add("SSD_SCT_ID", System.Type.GetType("System.Int64"));
            listTable.Columns.Add("SSD_STU_ID", System.Type.GetType("System.Int64"));
            listTable.Columns.Add("IS_OPTIONAL", System.Type.GetType("System.Boolean"));

            foreach (var frm in _ChangeGroupData)
            {
                listTable.Rows.Add(frm.SSD_ACD_ID,
                                     frm.SSD_GRD_ID,
                                     frm.SSD_SBG_ID,
                                     frm.SSD_SGR_ID,
                                     frm.SSD_SCT_ID,
                                     frm.SSD_STU_ID,
                                     frm.IS_OPTIONAL
                                     );
            }

            return listTable;
        }
        public async Task<IEnumerable<SelectedOptionByStudent>> GetSelectedOptionListByStudent(long ACD_ID, long STU_ID)
        {
            return await _SubjectSettingRepository.GetSelectedOptionListByStudent(ACD_ID, STU_ID);
        }
        public async Task<int> ChangeSelectedStudentGroup(ChangeSelectedStudentGroup changeSelectedStudentGroup)
        {
            return await _SubjectSettingRepository.ChangeSelectedStudentGroup(changeSelectedStudentGroup);
        }
        #endregion

        #region Upload Objective
        public async Task<int> BulkUploadObjective(UploadObjectiveModel uploadObjectiveModel)
        {
            DataTable dt = new DataTable();
            Dictionary<string, Type> columnList = new Dictionary<string, Type>();
            columnList.Add("OBJ_ID", typeof(int));
            columnList.Add("OBJ_DESC", typeof(string));
            columnList.Add("OBJ_START_DATE", typeof(DateTime));
            columnList.Add("OBJ_END_DATE", typeof(DateTime));
            columnList.Add("OBJ_LESSON_NO", typeof(int));
            columnList.Add("SUBTOPIC_DESC", typeof(string));
            columnList.Add("TOPIC_DESC", typeof(string));
            columnList.Add("STEPS", typeof(string));
            dt = CreateDataTableByModel(columnList);
            int OBJ_ID = 1;
            foreach (var item in uploadObjectiveModel.ObjectiveExcelModel)
            {
                dt.Rows.Add(OBJ_ID,
                            item.Objectives,
                            item.Start_Date,
                            item.End_Date,
                            item.No_of_Lessons,
                            item.Sub_Topic,
                            item.Topic,
                             item.Step
                            );
                OBJ_ID++;
            }
            return await _SubjectSettingRepository.BulkUploadObjective(uploadObjectiveModel, dt);
        }
        public static DataTable CreateDataTableByModel(Dictionary<string, Type> columnList)
        {
            DataTable dt = new DataTable("TableByModel");
            foreach (var item in columnList)
            {
                dt.Columns.Add(new DataColumn(item.Key, item.Value));
            }
            return dt;
        }
        public async Task<IEnumerable<TopicDetail>> GetTopicDetailList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID, long SYD_ID)
        {
            return await _SubjectSettingRepository.GetTopicDetailList(BSU_ID, ACD_ID, TRM_ID, GRD_ID, SBG_ID, SYD_ID);
        }
        public async Task<IEnumerable<TopicObjective>> GetTopicObjectiveList(long SYD_ID)
        {
            return await _SubjectSettingRepository.GetTopicObjectiveList(SYD_ID);
        }
        public async Task<IEnumerable<TopicParent>> GetTopicParentList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID)
        {
            return await _SubjectSettingRepository.GetTopicParentList(BSU_ID, ACD_ID, TRM_ID, GRD_ID, SBG_ID);
        }
        public async Task<int> AddEditTopicDetails(TopicDetail topicDetail, string DATAMODE)
        {           
            return await _SubjectSettingRepository.AddEditTopicDetails(topicDetail, DATAMODE);
        }
        public async Task<int> AddEditTopicObjective(TopicObjective topicObjective, string DATAMODE)
        {
            return await _SubjectSettingRepository.AddEditTopicObjective(topicObjective, DATAMODE);
        }
        #endregion
        #endregion

    }
}
