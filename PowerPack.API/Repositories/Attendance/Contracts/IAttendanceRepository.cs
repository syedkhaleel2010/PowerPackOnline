using DbConnection;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PowerPack.Models;

namespace SIMS.API.Repositories
{
    public interface IAttendanceRepository: IGenericRepository<Attendance>
    {
        Task<IEnumerable<Attendance>> GetAttendanceByIdAndDate(long acd_id, int ttm_id, string username, string entrydate, string grade = null, string section = null, string AttendanceType="Session1");
        Task<int> InsertAttendanceDetails(string student_xml, string entry_date, string username, int alg_id, int ttm_id = 0, string sct_id = "", string GRD_ID = "", long ACD_ID = 0, long BSU_ID = 0, long SHF_ID = 0, long STM_ID = 0,string AttendanceType="");

        Task<IEnumerable<ATTENDENCE_ANALYSIS>> Get_ATTENDENCE_ANALYSIS(String STU_ID);

        Task<IEnumerable<AttendenceBySession>> Get_AttendenceBySession(String STU_ID,DateTime EndDate);

        Task<IEnumerable<AttendenceSessionCode>> Get_AttendenceSessionCode(String STU_ID, DateTime EndDate);
        Task<IEnumerable<AttendanceChart>> Get_AttendanceChartMain(String STU_ID);

        Task<IEnumerable<RoomAttendance>> GetRoomAttendanceDetails(string USER_NAME,long TTM_ID,string GRD_ID,string SCT_ID,int ACD_ID, string entryDate);

        Task<IEnumerable<RoomAttendanceHeader>> GetRoomAttendanceHeader(long SGR_ID, DateTime ENTRY_DATE);

        bool InsertUpdateRoomAttendance(string SchoolId,string UserId,string Acd_Id, List<StudentRoomAttendance> objStudentRoomLog,List<StudentRoomAttendance> objStudentRoomAttendance);

        Task<IEnumerable<StudentRoomAttendance>> GetRoomAttendanceRemarksList(string entryDate,string schoolId,string UserId,int GroupId);

        Task<IEnumerable<GradeSectionAccess>> GetGradeSectionAccesses(long schoolId, long academicYear, string userName, string IsSuperUser, int gradeAccess, string gradeId);

        Task<IEnumerable<AttendanceSessionType>> GetAttendanceTypeByEntryDate(int acdId, string schoolId, DateTime AttendanceDt, string GrdId);

    }
}
