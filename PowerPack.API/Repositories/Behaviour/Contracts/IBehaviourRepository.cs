using DbConnection;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Repositories
{
    public interface IBehaviourRepository : IGenericRepository<Behaviour>
    {
        Task<IEnumerable<ClassList>> GetStudentList(string username, int tt_id = 0, string grade = null, string section = null);
        Task<IEnumerable<Behaviour>> LoadBehaviourByStudentId(string stu_id);
        Task<IEnumerable<BehaviourDetails>> GetBehaviourById(int id);
        Task<IEnumerable<BehaviourDetails>> InsertBehaviourDetails(BehaviourDetails entity, string bsu_id, string mode = "ADD");

        Task<IEnumerable<StudentBehaviour>> GetListOfStudentBehaviour();

        bool InsertUpdateStudentBehavior(List<StudentBehaviourFiles> studentBehaviourFiles,long studentId = 0, int behaviorId = 0, string behaviourComment = "");

        Task<IEnumerable<StudentBehaviour>> GetStudentBehaviorByStudentId(long studentId=0);

        bool InsertBulkStudentBehaviour(List<StudentBehaviourFiles> studentBehaviourFiles,string bulkStudentds = "", int behaviourId =0,string behaviourComment ="");

        bool UpdateBehaviourTypes(int behaviourId = 0, string behaviourType = "", int behaviourPoint = 0, int categoryId =0);

        Task<IEnumerable<StudentBehaviourMerit>> GetFileDetailsByStudentId(long studentId);

        Task<IEnumerable<StudentMeritList>> GetBehaviourClassList(string username, int tt_id = 0, string grade = null, string section = null);


        bool DeleteStudentBehaviourMapping(long studentId=0,int behaviourId = 0);

        Task<IEnumerable<SubCategories>> GetSubCategoriesByCategoryId(long categoryId, string BSU_ID, string GRD_ID);

        Task<IEnumerable<StudentBehaviourMerit>> GetMeritDetails(int acdId,string schoolId,long studentId);
        Task<IEnumerable<SubCategories>> GetMeritCategoryByStudent(int acdId, string schoolId, long studentId);
        bool InsertMeritDemerit(string schoolId, int academicId, StudentBehaviourMerit objBehaviourMerit, List<CategoryDetails> objCategories);

        #region Incident
        /// <summary>
        /// To get the list of incident
        /// </summary>
        /// <param name="schoolId">School Id to get Incident</param>
        /// <returns></returns>
        Task<IEnumerable<IncidentListModel>> GetIncidentList(long schoolId,long academicYearId, int month, long IncidentId);

        /// <summary>
        /// to get the list of student under incident
        /// </summary>
        /// <param name="IncidentId">Incident Id</param>
        /// <returns></returns>
        Task<IEnumerable<IncidentStudentList>> GetIncidentStudentList(long IncidentId);
        Task<IEnumerable<IncidentWitness>> GetIncidentWitnesses(long IncidentId);
        Task<IEnumerable<ChartModel>> GetIncidentChartByCategory(long schoolId, long academicYearId, int month,bool isCategory);
        Task<IEnumerable<IncidentStaffList>> GetIncidentStaffLists(long schoolId);
        Task<string> IncidentEntryCUD(IncidentEntry incidentEntry);
        #region IncidentAction
        Task<BehaviourAction> GetBehaviourAction(long incidentId, long studentId);
        Task<IEnumerable<BehaviourActionFollowup>> GetBehaviourActionFollowups(long incidentId, long actionId);
        Task<IEnumerable<FollowUpDesignation>> GetFollowUpDesignations(long schoolId, long incidentId);
        Task<IEnumerable<FollowUpStaff>> GetFollowUpStaffs(long schoolId, long designationId);
        Task<int> ActionCUD(BehaviourAction behaviourAction);
        Task<int> ActionFollowUpCUD(BehaviourActionFollowup behaviourActionFollowup);
        #endregion
        #endregion

        #region Student Points Category
        Task<IEnumerable<StudentPointCategory>> GetStudentPointCategory(long schoolId, long academicYearId, int scheduleType);
        Task<int> CertificateProcessLogCU(List<CertificateProcessLog> processLogs);
        #endregion
    }
}
