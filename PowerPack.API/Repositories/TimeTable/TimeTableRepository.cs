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
    public class TimeTableRepository : SqlRepository<TimeTable>, ITimeTableRepository
    {
        private readonly IConfiguration _config;

        public TimeTableRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override  Task<IEnumerable<TimeTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override  Task<TimeTable> GetAsync(int id)
        {
            //using (var conn = GetOpenConnection())
            //{
            //    var parameters = new DynamicParameters();
            //    parameters.Add("@ACD_ID", id, DbType.Int32);
            //    return await conn.QueryFirstAsync<TimeTable>("SIMS.GetGrades", parameters, null, null, CommandType.StoredProcedure);
            //}
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CalenderMonth>> GetCurrentMonth()
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<CalenderMonth>("DBO.GETFIRSTDAY_LASTDAY",null, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<TimeTable>> GetTimeTablesByUserandDate(string username, DateTime dateTime, string type, string grade = null, string section = null)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                    parameters.Add("@techUserName", username, DbType.String);
                    parameters.Add("@date", dateTime, DbType.DateTime);
                    parameters.Add("@option", type, DbType.String);
                if (grade != null)
                {
                    parameters.Add("@grade", grade, DbType.String);
                }
                if (section != null)
                {
                    parameters.Add("@section", section, DbType.String);
                }
                return await conn.QueryAsync<TimeTable>("SIMS.GETTEACHERDETAILS", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TimeTable>> GetTimeTableSchedule(string username, DateTime date)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@username", username, DbType.String);
                parameters.Add("@date", date, DbType.DateTime);
                return await conn.QueryAsync<TimeTable>("SIMS.GetTimeTableSchedule", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public override void InsertAsync(TimeTable entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(TimeTable entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
