using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIMS.API.Services
{
    public interface ITimeTableService
    {
        Task<IEnumerable<CalenderMonth>> GetCurrentMonth();
        Task<IEnumerable<TimeTable>> GetTimeTablesByUserandDate(string username, DateTime dateTime, string type, string grade = null, string section = null);
        Task<IEnumerable<TimeTable>> GetTimeTableSchedule(string username, DateTime date);
        //Task<IEnumerable<Sections>> GetSectionsByTimeTable(int id);
    }
}
