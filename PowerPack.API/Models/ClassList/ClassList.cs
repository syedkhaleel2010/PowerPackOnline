using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models
{
    public class ClassList
    {
        public ClassList() { }
        public ClassList(int _TimeTableId)
        {
            TimeTableID = _TimeTableId;
        }
        public int TimeTableID { get; set; }
        public string Student_Name { get; set; }
        public string Student_No { get; set; }
        public string Student_ID { get; set; }
        public string Student_Image_url { get; set; }
        public string Student_Grade { get; set; }
        public string Student_Section { get; set; }
        public string Student_Flag_Status { get; set; }

        public int Behaviourpoint { get; set; }
        public int PositivePoint { get; set; }
        public int NegativePoint { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsInReport { get; set; }

    }
    public class StudentOnReportMaster
    {
        public long Id { get; set; }
        public long AcademicYearId { get; set; }
        public long SchoolId { get; set; }
        public string GradeId { get; set; }
        public long? SectionId { get; set; }
        public string GroupId { get; set; }
        public long StudentId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
    public class StudentOnReportDetail
    {
        public long Id { get; set; }
        public long StudentOnReportMasterId { get; set; }
        public long PeriodNo { get; set; }
        public string PeriodName { get; set; }
        public string Description { get; set; }
        public string GroupId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class StudentOnReportDetailsParameter
    {
        public long StudentId { get; set; }
        public long? StudentOnReportMasterId { get; set; } = null;
        public long AcademicYear { get; set; }
        public long SchoolId { get; set; }
        public string CreatedBy { get; set; } = null;
        public string GroupId { get; set; } = null;
    }
}
