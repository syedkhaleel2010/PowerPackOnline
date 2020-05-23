using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface IClassListService
    {
        Task<IEnumerable<ClassList>> GetClassList(string username, int tt_id = 0, string grade = null, string section = null);
        Task<BasicDetails> GetStudentDetails(string stu_id);
        Task<ParentDetails> GetProfileParentDetails(string stu_id);

        Task<IEnumerable<SiblingDetails>> GetSiblingDetails(string stu_id);

        Task<TransportDetails> GetTransportDetails(string stu_id);
        Task<MedicalDetails> GetMedicalDetails(string stu_id);
        Task<IEnumerable<BehaviorDetails>> GetBehaviorDetail(long STU_ID);
        Task<StudentDashboardDetails> GetStudentDashboardDetails(string stu_id);

        Task<IEnumerable<ActivitiesDetails>> GetActivitiesDetails(string stu_id);
        Task<IEnumerable<AttendanceChart>> GetAttendanceChart(string stu_id);
        Task<IEnumerable<dynamic>> GetAssessmentDetails(string stu_id);
        Task<IEnumerable<AttendenceList>> GetAttendenceList(string stu_id,DateTime EndDate);
        Task<long> StudentOnReportMasterCU(StudentOnReportMaster studentOnReport);
        Task<IEnumerable<StudentOnReportMaster>> GetStudentOnReportMasters(long studentId, long academicYearId, long schoolId);
        Task<long> StudentOnReportDetailsCU(StudentOnReportDetail studentOnReport);
        Task<IEnumerable<StudentOnReportDetail>> GetStudentOnReportDetails(StudentOnReportDetailsParameter detailsParameter);

        Task<IEnumerable<ClassList>> GetStudentPhotoPath(string BSU_ID, long RPF_ID, string STU_ID);
    }
}
