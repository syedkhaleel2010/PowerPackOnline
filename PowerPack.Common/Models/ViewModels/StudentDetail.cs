using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.ViewModels
{
    public class StudentDetail
    {
        public int UserId { get; set; }
        public int SchoolId { get; set; }
        public int UserTypeId { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }
        public string StudentNumber{ get; set; }
        public string SchoolName { get; set; }
        public string UserTypeName { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public int AcademicYearId { get; set; }
        public int StudentGradeId { get; set; }
        public string CurrentStatus { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string SchoolLogo { get; set; }
        public string StudentImage { get; set; }


        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Standard { get; set; }

        public string SchoolBusinessUnitName { get; set; }
        public string SchoolBusinessUnitCode { get; set; }
        public string SchoolBusinessUnitEmail { get; set; }
        public string SchoolBusinessUnitTypeId { get; set; }
        public string SchoolBusinessUnitType { get; set; }
       
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public bool IsSuperAdmin { get; set; }
        public string UserDisplayName { get; set; }
        public string PhoneNumber { get; set; }
        

        public string Occupation { get; set; }
        public string Company { get; set; }
        public string Class { get; set; }
        public string GradeDisplay { get; set; }
        public string SectionName{ get; set; }
        public int ParentId { get; set; }
        public string ParentUserName { get; set; }

    }
}
