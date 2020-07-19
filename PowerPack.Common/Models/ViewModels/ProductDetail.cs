using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.ViewModels
{
    public class ProductDetail
    {
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public int UserTypeId { get; set; }
        public int ProductId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }
        public string ProductNumber{ get; set; }
        public string StoreName { get; set; }
        public string UserTypeName { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public int ProductGradeId { get; set; }
        public string CurrentStatus { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string StoreLogo { get; set; }
        public string ProductImage { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Standard { get; set; }
        public string StoreBusinessUnitName { get; set; }
        public string StoreBusinessUnitCode { get; set; }
        public string StoreBusinessUnitEmail { get; set; }
        public string StoreBusinessUnitTypeId { get; set; }
        public string StoreBusinessUnitType { get; set; }       
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
        public int PowerPackId { get; set; }
        public int StoreAcademicYearId { get; set; }
        public int PowerPackStoreAcademicYearId { get; set; }

    }
}
