using DbConnection;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Repositories
{
    public interface IClassListRepository : IGenericRepository<ClassList>
    {
        Task<IEnumerable<ClassList>> GetClassList(string username, int tt_id = 0, string grade = null, string section = null);
        Task<BasicDetails> GetStudentDetails(string stu_id);
        Task<ParentDetails> GetProfileParentDetails(string stu_id);

        Task<IEnumerable<SiblingDetails>> GetSiblingDetails(string stu_id);
        Task<TransportDetails> GetTransportDetails(string stu_id);

        Task<MedicalDetails> GetMedicalDetails(string STU_ID);
        Task<StudentDashboardDetails> GetStudentDashboardDetails(string STU_ID);
        Task<IEnumerable<ActivitiesDetails>> GetActivitiesDetails(string STU_ID);
        Task<IEnumerable<AttendanceChart>> GetAttendanceChart(string STU_ID);
        Task<IEnumerable<dynamic>> GetAssessmentDetails(string STU_ID);
        Task<IEnumerable<AttendenceList>> GetAttendenceList(string STU_ID,DateTime EndDate);
        Task<IEnumerable<BehaviorDetails>> GetBehaviorDetail(long STU_ID);
        Task<long> StudentOnReportMasterCU(StudentOnReportMaster studentOnReport);
        Task<IEnumerable<StudentOnReportMaster>> GetStudentOnReportMasters(long studentId, long academicYearId, long schoolId);
        Task<long> StudentOnReportDetailsCU(StudentOnReportDetail studentOnReport);
        Task<IEnumerable<StudentOnReportDetail>> GetStudentOnReportDetails(StudentOnReportDetailsParameter detailsParameter);
        Task<IEnumerable<ClassList>> GetStudentPhotoPath(string BSU_ID, long RPF_ID, string STU_ID);
    }
}
