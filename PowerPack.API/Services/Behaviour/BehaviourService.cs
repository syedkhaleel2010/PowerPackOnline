using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Services
{
    public class BehaviourService : IBehaviourService
    {
        private readonly IBehaviourRepository _BehaviourRepository;

        public BehaviourService(IBehaviourRepository BehaviourRepository)
        {
            _BehaviourRepository = BehaviourRepository;
        }
        public async Task<IEnumerable<ClassList>> GetStudentList(string username, int tt_id = 0, string grade = null, string section = null)
        {
            return await _BehaviourRepository.GetStudentList(username, tt_id, grade, section);
        }
        public async Task<IEnumerable<Behaviour>> LoadBehaviourByStudentId(string stu_id)
        {
            return await _BehaviourRepository.LoadBehaviourByStudentId(stu_id);
        }
        public async Task<IEnumerable<BehaviourDetails>> GetBehaviourById(int stu_id)
        {
            return await _BehaviourRepository.GetBehaviourById(stu_id);
        }
        public async Task<IEnumerable<BehaviourDetails>> InsertBehaviourDetails(BehaviourDetails entity, string bsu_id, string mode = "ADD")
        {
            return await _BehaviourRepository.InsertBehaviourDetails(entity, bsu_id, mode);
        }

        public async Task<IEnumerable<StudentBehaviour>> GetListOfStudentBehaviour()
        {
            return await _BehaviourRepository.GetListOfStudentBehaviour();
        }

        public bool InsertUpdateStudentBehavior(List<StudentBehaviourFiles> studentBehaviourFiles, long studentId = 0, int behaviorId = 0, string behaviourComment = "")
        {
            return _BehaviourRepository.InsertUpdateStudentBehavior(studentBehaviourFiles, studentId, behaviorId, behaviourComment);
        }

        public async Task<IEnumerable<StudentBehaviour>> GetStudentBehaviorByStudentId(long studentId = 0)
        {
            return await _BehaviourRepository.GetStudentBehaviorByStudentId(studentId);
        }

        public bool InsertBulkStudentBehaviour(List<StudentBehaviourFiles> studentBehaviourFiles, string bulkStudentds = "", int behaviourId = 0, string behaviourComment = "")
        {
            return _BehaviourRepository.InsertBulkStudentBehaviour(studentBehaviourFiles, bulkStudentds, behaviourId, behaviourComment);
        }

        public bool UpdateBehaviourTypes(int behaviourId = 0, string behaviourType = "", int behaviourPoint = 0, int categoryId = 0)
        {
            return _BehaviourRepository.UpdateBehaviourTypes(behaviourId, behaviourType, behaviourPoint, categoryId);
        }

        public async Task<IEnumerable<StudentBehaviourMerit>> GetFileDetailsByStudentId(long studentId)
        {
            return await _BehaviourRepository.GetFileDetailsByStudentId(studentId);
        }

        public async Task<IEnumerable<StudentMeritList>> GetBehaviourClassList(string username, int tt_id = 0, string grade = null, string section = null)
        {
            return await _BehaviourRepository.GetBehaviourClassList(username, tt_id, grade, section);
        }

        public bool DeleteStudentBehaviourMapping(long studentId = 0, int behaviourId = 0)
        {
            return _BehaviourRepository.DeleteStudentBehaviourMapping(studentId, behaviourId);
        }

        public async Task<IEnumerable<SubCategories>> GetSubCategoriesByCategoryId(long categoryId, string BSU_ID, string GRD_ID)
        {
            return await _BehaviourRepository.GetSubCategoriesByCategoryId(categoryId, BSU_ID, GRD_ID);
        }

        public async Task<IEnumerable<StudentBehaviourMerit>> GetMeritDetails(int acdId, string schoolId, long studentId)
        {
            return await _BehaviourRepository.GetMeritDetails( acdId,  schoolId,  studentId);
        }
        public async Task<IEnumerable<SubCategories>> GetMeritCategoryByStudent(int acdId, string schoolId, long studentId)
        {
            return await _BehaviourRepository.GetMeritCategoryByStudent (acdId, schoolId, studentId);
        }
        public bool InsertMeritDemerit(string schoolId, int academicId, MeritDemerit objMeritDemerit)
        {
            return _BehaviourRepository.InsertMeritDemerit(schoolId, academicId, objMeritDemerit.objMeritDemerit, objMeritDemerit.objListOfCategories);
        }
        #region Incident
        public async Task<IEnumerable<IncidentListModel>> GetIncidentList(long schoolId, long academicYearId, int month, long incidentId)
        {
            return await _BehaviourRepository.GetIncidentList(schoolId, academicYearId, month, incidentId);
        }
        public async Task<IEnumerable<IncidentStudentList>> GetIncidentStudentList(long IncidentId)
        {
            return await _BehaviourRepository.GetIncidentStudentList(IncidentId);
        }
        public async Task<IEnumerable<IncidentWitness>> GetIncidentWitnesses(long IncidentId)
        {
            return await _BehaviourRepository.GetIncidentWitnesses(IncidentId);
        }
        public async Task<IEnumerable<ChartModel>> GetIncidentChartByCategory(long schoolId, long academicYearId, int month, bool isCategory)
        {
            return await _BehaviourRepository.GetIncidentChartByCategory(schoolId, academicYearId, month, isCategory);
        }

        public async Task<IEnumerable<IncidentStaffList>> GetIncidentStaffLists(long schoolId)
        {
            return await _BehaviourRepository.GetIncidentStaffLists(schoolId);
        }

        public async Task<string> IncidentEntryCUD(IncidentEntry incidentEntry)
        {
            return await _BehaviourRepository.IncidentEntryCUD(incidentEntry);
        }
        #region IncidentAction
        public async Task<BehaviourAction> GetBehaviourAction(long incidentId, long studentId)
        {
            return await _BehaviourRepository.GetBehaviourAction(incidentId, studentId);
        }

        public async Task<IEnumerable<BehaviourActionFollowup>> GetBehaviourActionFollowups(long incidentId, long actionId)
        {
            return await _BehaviourRepository.GetBehaviourActionFollowups(incidentId, actionId);
        }

        public async Task<IEnumerable<FollowUpDesignation>> GetFollowUpDesignations(long schoolId, long incidentId)
        {
            return await _BehaviourRepository.GetFollowUpDesignations(schoolId, incidentId);
        }

        public async Task<IEnumerable<FollowUpStaff>> GetFollowUpStaffs(long schoolId, long designationId)
        {
            return await _BehaviourRepository.GetFollowUpStaffs( schoolId,  designationId);
        }

        public async Task<int> ActionCUD(BehaviourAction behaviourAction)
        {
            return await _BehaviourRepository.ActionCUD(behaviourAction);
        }

        public async Task<int> ActionFollowUpCUD(BehaviourActionFollowup behaviourActionFollowup)
        {
            return await _BehaviourRepository.ActionFollowUpCUD(behaviourActionFollowup);
        }






        #endregion
        #endregion

        #region Student Points Category
        public async Task<IEnumerable<StudentPointCategory>> GetStudentPointCategory(long schoolId, long academicYearId, int scheduleType)
        {
            return await _BehaviourRepository.GetStudentPointCategory(schoolId, academicYearId,scheduleType);
        }
        public async Task<int> CertificateProcessLogCU(List<CertificateProcessLog> processLogs) => 
            await _BehaviourRepository.CertificateProcessLogCU(processLogs);
        #endregion
    }
}
