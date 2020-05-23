using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SIMS.API.Repositories
{
    public class ClassListRepository : SqlRepository<ClassList>, IClassListRepository
    {
        private readonly IConfiguration _config;

        public ClassListRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ClassList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<ClassList> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClassList>> GetClassList(string username, int tt_id = 0, string grade = null, string section = null)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@USER_NAME", username, DbType.String);
                parameters.Add("@TTM_ID", tt_id, DbType.Int32);
                parameters.Add("@GRD_ID", grade, DbType.String);
                parameters.Add("@SCT_ID", section, DbType.String);
                return await conn.QueryAsync<ClassList>("SIMS.GETCLASSLIST", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<BasicDetails> GetStudentDetails(string STU_ID)
        {
            var option = "STUDENT";
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String);
                parameters.Add("@Option", option, DbType.String);
                return await conn.QueryFirstOrDefaultAsync<BasicDetails>("SIMS.GET_STUDENT_PROFILE", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<ParentDetails> GetProfileParentDetails(string STU_ID)
        {
            var option = "PARENT";
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String);
                parameters.Add("@Option", option, DbType.String);
                return await conn.QueryFirstOrDefaultAsync<ParentDetails>("SIMS.GET_STUDENT_PROFILE", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<SiblingDetails>> GetSiblingDetails(string STU_ID)
        { 
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String);
                //return await conn.QueryFirstOrDefaultAsync<IEnumerable<SiblingDetails>>("SIMS.GET_SIBLINGS_BY_STU_ID", parameters, null, null, CommandType.StoredProcedure);
                return await conn.QueryAsync<SiblingDetails>("SIMS.GET_SIBLINGS_BY_STU_ID", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        


        public async Task<TransportDetails> GetTransportDetails(string STU_ID)
        { 
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String); 
                return await conn.QueryFirstOrDefaultAsync<TransportDetails>("SIMS.GET_TRANSPORT_DETAILS", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<MedicalDetails> GetMedicalDetails(string STU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String);
                return await conn.QueryFirstOrDefaultAsync<MedicalDetails>("SIMS.GETHEALTHINFO_For_GWA", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<BehaviorDetails>> GetBehaviorDetail(long STU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.Int64);
                return await conn.QueryAsync<BehaviorDetails>("SIMS.GetBehaviorDetail", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<StudentDashboardDetails> GetStudentDashboardDetails(string STU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String);
                return await conn.QueryFirstOrDefaultAsync<StudentDashboardDetails>("SIMS.GET_STUDENT_DETAILS_DASHBOARD", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ActivitiesDetails>> GetActivitiesDetails(string STU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String);
              //  return await conn. <IEnumerable<ActivitiesDetails>>("SIMS.GET_ACTIVITY_BY_STU_ID", parameters, null, null, CommandType.StoredProcedure);
                return await conn.QueryAsync<ActivitiesDetails>("SIMS.GET_ACTIVITY_BY_STU_ID", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<AttendanceChart>> GetAttendanceChart(string STU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String);
                //  return await conn. <IEnumerable<ActivitiesDetails>>("SIMS.GET_ACTIVITY_BY_STU_ID", parameters, null, null, CommandType.StoredProcedure);
                return await conn.QueryAsync<AttendanceChart>("SIMS.GETSTUDDASHBOARD_ATT_PATTENBY_ID", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<dynamic>> GetAssessmentDetails(string STU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String); 
                return await conn.QueryAsync("SIMS.GET_ASSESMENT", parameters,commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<AttendenceList>> GetAttendenceList(string STU_ID,DateTime EndDate)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", STU_ID, DbType.String);
                parameters.Add("@ENDDATE", EndDate, DbType.DateTime);
                return await conn.QueryAsync<AttendenceList>("SIMS.GET_STUDENT_ATTENDENCE_HISTORY", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public override void InsertAsync(ClassList entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(ClassList entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<long> StudentOnReportMasterCU(StudentOnReportMaster studentOnReport)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SRM_ID", studentOnReport.Id);
                parameters.Add("@SRM_ACD_ID", studentOnReport.AcademicYearId); 
                parameters.Add("@SRM_BSU_ID", studentOnReport.SchoolId);
                parameters.Add("@SRM_GRD_ID", studentOnReport.GradeId);
                parameters.Add("@SRM_SCT_ID", studentOnReport.SectionId);
                parameters.Add("@SRM_GROUP_ID", studentOnReport.GroupId);
                parameters.Add("@SRM_STU_ID", studentOnReport.StudentId);
                parameters.Add("@SRM_FROM_DATE", studentOnReport.FromDate);
                parameters.Add("@SRM_TO_DATE", studentOnReport.ToDate);
                parameters.Add("@SRM_DESC", studentOnReport.Description);
                parameters.Add("@SRM_CREATED_BY", studentOnReport.CreatedBy);
                parameters.Add("@SRM_IsActive", studentOnReport.IsActive);
                parameters.Add("@OUTPUT", dbType: DbType.Int64, direction: ParameterDirection.Output);
                await conn.QueryAsync("SIMS.StudentOnReportMasterCU", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<long>("OUTPUT");
            }
        }

        public async Task<IEnumerable<StudentOnReportMaster>> GetStudentOnReportMasters(long studentId, long academicYearId, long schoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SRM_STU_ID", studentId);
                parameters.Add("@SRM_ACD_ID", academicYearId);
                parameters.Add("@SRM_BSU_ID", schoolId);
                return await conn.QueryAsync<StudentOnReportMaster>("SIMS.GetStudentOnReportMaster", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<long> StudentOnReportDetailsCU(StudentOnReportDetail studentOnReport)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SRD_ID", studentOnReport.Id);
                parameters.Add("@SRD_SRM_ID", studentOnReport.StudentOnReportMasterId);
                parameters.Add("@SRD_PERIOD_NO", studentOnReport.PeriodNo);
                parameters.Add("@SRD_DESC", studentOnReport.Description);
                parameters.Add("@SRD_GROUP_ID", studentOnReport.GroupId);
                parameters.Add("@SRD_CREATED_BY", studentOnReport.CreatedBy);
                parameters.Add("@SRD_CREATED_ON", studentOnReport.CreatedOn);
                parameters.Add("@IsActive", studentOnReport.IsActive);
                parameters.Add("@OUTPUT", dbType: DbType.Int64, direction: ParameterDirection.Output);
                await conn.QueryAsync("SIMS.StudentOnReportDetailCU", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<long>("OUTPUT");
            }
        }

        public async Task<IEnumerable<StudentOnReportDetail>> GetStudentOnReportDetails(StudentOnReportDetailsParameter detailsParameter)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SRM_STU_ID", detailsParameter.StudentId);
                parameters.Add("@SRM_ACD_ID", detailsParameter.AcademicYear);
                parameters.Add("@SRM_BSU_ID", detailsParameter.SchoolId);
                parameters.Add("@SRD_SRM_ID", detailsParameter.StudentOnReportMasterId);
                parameters.Add("@SRD_CREATED_BY", detailsParameter.CreatedBy);
                parameters.Add("@SRD_GROUP_ID", detailsParameter.GroupId);
                return await conn.QueryAsync<StudentOnReportDetail>("SIMS.GetStudentOnReportDetail", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ClassList>> GetStudentPhotoPath(string BSU_ID,long RPF_ID,string STU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                
                parameters.Add("@STU_ID", STU_ID, DbType.String);
                parameters.Add("@RPF_ID", RPF_ID, DbType.Int64);
                parameters.Add("@BSU_ID", BSU_ID, DbType.String);
                return await conn.QueryAsync<ClassList>("RPT.GET_STUDENT_PHOTO_PATH", parameters, null, null, CommandType.StoredProcedure);
            }
        }
    }
}
