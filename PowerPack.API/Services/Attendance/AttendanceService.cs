using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PowerPack.Models;

namespace SIMS.API.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _AttendanceRepository;

        public AttendanceService(IAttendanceRepository AttendanceRepository)
        {
            _AttendanceRepository = AttendanceRepository;
        }
        public async Task<IEnumerable<Attendance>> GetAttendanceByIdAndDate(long acd_id, int ttm_id, string username, string entrydate, string grade = null, string section = null, string AttendanceType = "Session1")
        {
            return await _AttendanceRepository.GetAttendanceByIdAndDate(acd_id,ttm_id, username, entrydate, grade, section, AttendanceType);
        }
        public async Task<int> InsertAttendanceDetails(string student_xml, string entry_date, string username, int alg_id, int ttm_id = 0, string sct_id = "", string GRD_ID = "", long ACD_ID = 0, long BSU_ID = 0, long SHF_ID = 0, long STM_ID = 0, string AttendanceType = "")
        {
           return await _AttendanceRepository.InsertAttendanceDetails(student_xml, entry_date, username, alg_id, ttm_id, sct_id , GRD_ID, ACD_ID, BSU_ID, SHF_ID, STM_ID, AttendanceType);
        }

        public async Task<IEnumerable<ATTENDENCE_ANALYSIS>> Get_ATTENDENCE_ANALYSIS(String STU_ID)
        {
            return await _AttendanceRepository.Get_ATTENDENCE_ANALYSIS(STU_ID);
        }

        public async Task<IEnumerable<AttendenceBySession>> Get_AttendenceBySession(String STU_ID,DateTime EndDate)
        {
            return await _AttendanceRepository.Get_AttendenceBySession(STU_ID, EndDate);
        }

        public async Task<IEnumerable<AttendenceSessionCode>> Get_AttendenceSessionCode(String STU_ID, DateTime EndDate)
        {
            return await _AttendanceRepository.Get_AttendenceSessionCode(STU_ID, EndDate);
        }
        public async Task<IEnumerable<AttendanceChart>> Get_AttendanceChartMain(String STU_ID)
        {
            return await _AttendanceRepository.Get_AttendanceChartMain(STU_ID);
        }

        public async Task<IEnumerable<RoomAttendance>> GetRoomAttendanceDetails(string USER_NAME, long TTM_ID, string GRD_ID, string SCT_ID, int ACD_ID, string entryDate)
        {
            return await _AttendanceRepository.GetRoomAttendanceDetails( USER_NAME,  TTM_ID,  GRD_ID,  SCT_ID,  ACD_ID, entryDate);
        }

        public async Task<IEnumerable<RoomAttendanceHeader>> GetRoomAttendanceHeader(long SGR_ID, DateTime ENTRY_DATE)
        {
            return await _AttendanceRepository.GetRoomAttendanceHeader(SGR_ID, ENTRY_DATE);
        }

        public bool InsertUpdateRoomAttendance(string SchoolId, string UserId, string Acd_Id, List<StudentRoomAttendance> objStudentRoomLog, List<StudentRoomAttendance> objStudentRoomAttendance)
        {
            return _AttendanceRepository.InsertUpdateRoomAttendance( SchoolId,  UserId,  Acd_Id, objStudentRoomLog, objStudentRoomAttendance);
        }

        public async Task<IEnumerable<StudentRoomAttendance>> GetRoomAttendanceRemarksList(string entryDate, string schoolId, string UserId, int GroupId)
        {
            return await _AttendanceRepository.GetRoomAttendanceRemarksList(entryDate, schoolId, UserId, GroupId);
        }

        public async Task<IEnumerable<GradeSectionAccess>> GetGradeSectionAccesses(long schoolId, long academicYear, string userName, string IsSuperUser, int gradeAccess, string gradeId)
        {
            return await _AttendanceRepository.GetGradeSectionAccesses(schoolId, academicYear, userName, IsSuperUser, gradeAccess, gradeId);
        }

        public async Task<IEnumerable<AttendanceSessionType>> GetAttendanceTypeByEntryDate(int acdId, string schoolId, DateTime AttendanceDt, string GrdId)
        {
            return await _AttendanceRepository.GetAttendanceTypeByEntryDate( acdId,  schoolId,  AttendanceDt,  GrdId);
        }
    }
}
