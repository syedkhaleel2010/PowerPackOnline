using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models
{
    public class TimeTable
    {
        public TimeTable() { }
        public TimeTable(int _TimeTableId)
        {
            TimeTableID = _TimeTableId;
        }
        public string Day { get; set; }
        public int TimeTableID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ClassRoom { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public string StatusCss { get; set; }
        public string entry_date { get; set; }
        public int TT_Sequence { get; set; }

        public int PeriodNo { get; set; }
    }

    public class CalenderMonth
    {
        public string Days { get; set; }
        public string Day_Name { get; set; }
        public DateTime Date_Value { get; set; }
        public string Months { get; set; }
    }

}
