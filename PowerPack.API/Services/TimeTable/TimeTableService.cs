using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Services
{
    public class TimeTableService : ITimeTableService
    {
        private readonly ITimeTableRepository _TimeTableRepository;

        public TimeTableService(ITimeTableRepository TimeTableRepository)
        {
            _TimeTableRepository = TimeTableRepository;
        }

        public async Task<IEnumerable<CalenderMonth>> GetCurrentMonth()
        {
            return await _TimeTableRepository.GetCurrentMonth();
        }

        public async Task<IEnumerable<TimeTable>> GetTimeTablesByUserandDate(string username, DateTime dateTime, string type, string grade = null, string section = null)
        {
            return await _TimeTableRepository.GetTimeTablesByUserandDate(username, dateTime, type, grade, section);
        }
        //public async Task<IEnumerable<TimeTable>> GetTimeTablesByACD(int id)
        //{
        //    return await _TimeTableRepository.GetList(id);
        //}
        public async Task<IEnumerable<TimeTable>> GetTimeTableSchedule(string username, DateTime date)
            => await _TimeTableRepository.GetTimeTableSchedule(username, date);
    }
}
