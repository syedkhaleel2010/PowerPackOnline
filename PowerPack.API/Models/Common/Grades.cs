using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models
{
    public class Grades
    {
            public Grades() { }
            public Grades(int _GradeId)
            {
            SchoolGradeId = _GradeId;
            }
            public int SchoolGradeId { get; set; }
            public int SchoolAcademicYearId { get; set; }
            public string GradeDisplay { get; set; }
        }
    public class Sections
    {
        public Sections() { }
        public Sections(int _SectionId)
        {
            SectionId = _SectionId;
        }
        public int SectionId { get; set; }
        public int SchoolGradeId { get; set; }
        public string SectionName { get; set; }
    }

}
