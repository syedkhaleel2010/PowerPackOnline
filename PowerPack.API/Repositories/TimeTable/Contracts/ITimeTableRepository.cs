using DbConnection;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Repositories
{
    public interface ITimeTableRepository: IGenericRepository<TimeTable>
    {
        Task<IEnumerable<CalenderMonth>> GetCurrentMonth();
        Task<IEnumerable<TimeTable>> GetTimeTablesByUserandDate(string username, DateTime dateTime , string type , string  grade=null , string section=null);
        Task<IEnumerable<TimeTable>> GetTimeTableSchedule(string username, DateTime date);
    }
}
