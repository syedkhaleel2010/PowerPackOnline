using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Services
{
    public class ClassListService : IClassListService
    {
        private readonly IClassListRepository _ClassListRepository;

        public ClassListService(IClassListRepository ClassListRepository)
        {
            _ClassListRepository = ClassListRepository;
        }
        public async Task<IEnumerable<ClassList>> GetClassList(string username,int tt_id=0, string grade = null, string section = null)
        {
            return await _ClassListRepository.GetClassList(username,tt_id,grade,section);
        }
        public async Task<BasicDetails> GetStudentDetails(string stu_id)
        {
            return await _ClassListRepository.GetStudentDetails(stu_id);
        }
        public async Task<ParentDetails> GetProfileParentDetails(string stu_id)
        {
            return await _ClassListRepository.GetProfileParentDetails(stu_id);
        }

        public async Task<IEnumerable<SiblingDetails>> GetSiblingDetails(string stu_id)
        {
            return await _ClassListRepository.GetSiblingDetails(stu_id);
        }

        public async Task<TransportDetails> GetTransportDetails(string stu_id)
        {
            return await _ClassListRepository.GetTransportDetails(stu_id);
        }

        public async Task<MedicalDetails> GetMedicalDetails(string stu_id)
        {
            return await _ClassListRepository.GetMedicalDetails(stu_id);
        }
        public async Task<IEnumerable<BehaviorDetails>> GetBehaviorDetail(long STU_ID)
        {
            return await _ClassListRepository.GetBehaviorDetail(STU_ID);
        }
        public async Task<StudentDashboardDetails> GetStudentDashboardDetails(string stu_id)
        {
            return await _ClassListRepository.GetStudentDashboardDetails(stu_id);
        }

        public async Task<IEnumerable<ActivitiesDetails>> GetActivitiesDetails(string stu_id)
        {
            return await _ClassListRepository.GetActivitiesDetails(stu_id);
        }

        public async Task<IEnumerable<AttendanceChart>> GetAttendanceChart(string stu_id)
        {
            return await _ClassListRepository.GetAttendanceChart(stu_id);
        }

        public async Task<IEnumerable<dynamic>> GetAssessmentDetails(string stu_id)
        {
            return await _ClassListRepository.GetAssessmentDetails(stu_id);
        }
        public async Task<IEnumerable<AttendenceList>> GetAttendenceList(string stu_id,DateTime EndDate)
        {
            return await _ClassListRepository.GetAttendenceList(stu_id, EndDate);
        }

        public async Task<long> StudentOnReportMasterCU(StudentOnReportMaster studentOnReport)
        {
            return await _ClassListRepository.StudentOnReportMasterCU(studentOnReport);
        }

        public async Task<IEnumerable<StudentOnReportMaster>> GetStudentOnReportMasters(long studentId, long academicYearId, long schoolId)
        {
            return await _ClassListRepository.GetStudentOnReportMasters(studentId, academicYearId, schoolId);
        }

        public async Task<long> StudentOnReportDetailsCU(StudentOnReportDetail studentOnReport)
        {
            return await _ClassListRepository.StudentOnReportDetailsCU(studentOnReport);
        }

        public async Task<IEnumerable<StudentOnReportDetail>> GetStudentOnReportDetails(StudentOnReportDetailsParameter detailsParameter)
        {
            return await _ClassListRepository.GetStudentOnReportDetails(detailsParameter);
        }

        public async Task<IEnumerable<ClassList>> GetStudentPhotoPath(string BSU_ID, long RPF_ID, string STU_ID)
        {
            return await _ClassListRepository.GetStudentPhotoPath( BSU_ID,  RPF_ID,  STU_ID);
        }
    }
}
