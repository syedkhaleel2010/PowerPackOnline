using PowerPack.Common.ViewModels;
using PowerPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace PowerPack.Common.Extensions
{
    interface IUserPrincipal : IPrincipal
    {
        Int64 Id { get; set; }
        Int64 OldUserId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        Int64 SchoolId { get; set; }
        string SchoolName { get; set; }
        string SchoolCode { get; set; }
        string SchoolEmail { get; set; }

        int BusinessUnitTypeId { get; set; }
        string BusinessUnitType { get; set; }

        int LanguageId { get; set; }

        bool IsAdmin { get; set; }
        int UserTypeId { get; set; }
        string UserTypeName { get; set; }

        int RoleId { get; set; }
        string RoleName { get; set; }
        bool IsMSOAdmin { get; set; }
        long SessionId { get; set; }
        int IsSTS { get; set; }
    }
    public class UserPrincipal : IUserPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }
        public UserPrincipal()
        {
            FamilyStudentList = new List<StudentDetail>();
        }
        public UserPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
            FamilyStudentList = new List<StudentDetail>();
            TerminologyCollection = new List<Tuple<long,string,string>>();
        }

        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 OldUserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Int64 SchoolId { get; set; }
        public Int64 SchoolGradeId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCode { get; set; }
        public string SchoolEmail { get; set; }
        public int BusinessUnitTypeId { get; set; }
        public string BusinessUnitType { get; set; }
        public int LanguageId { get; set; }
        public bool IsAdmin { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public UserTypes UserType { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string SchoolImage { get; set; }
        public string ProfilePhoto { get; set; }
        public string UserAvatar { get; set; }
        public int ParentId { get; set; }
        public string ParentUsername { get; set; }
        public List<StudentDetail> FamilyStudentList { get; set; }
        public StudentDetail CurrentSelectedStudent { get; set; }
        public string Token { get; set; }
        public int ACD_ID { get; set; }
        public int CLM_ID { get; set; }
        public string CLM_DESCR { get; set; }
        public IEnumerable<Tuple<long,string,string>> TerminologyCollection { get; set; }

        public bool HasMultipleChilds()
        {
            return FamilyStudentList != null && FamilyStudentList.Count() > 1;
        }
        public bool IsParent()
        {
            return UserType == UserTypes.Parent;
        }
        public bool IsStudent()
        {
            return UserType == UserTypes.Student;
        }
        public bool IsTeacher()
        {
            return UserType == UserTypes.Teacher;
        }

        public bool IsMSOAdmin { get; set; }
        public string CurrentModuleURL { get; set; }
        public string StudentTheme { get; set; }
        public long SessionId { get; set; }
        public int IsSTS { get; set; }
  
    }

    public class UserPrincipalSerializeModel
    {
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 OldUserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Int64 SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCode { get; set; }
        public string SchoolEmail { get; set; }
        public int BusinessUnitTypeId { get; set; }
        public string BusinessUnitType { get; set; }
        public int LanguageId { get; set; }
        public bool IsAdmin { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string SchoolImage { get; set; }
        public string ProfilePhoto { get; set; }
        public string UserAvatar { get; set; }
        public string FamilyStudentListJsonString { get; set; }
        public string CurrentSelectedStudentJsonString { get; set; }
        public int ParentId { get; set; }
        public string ParentUsername { get; set; }
        public string AccessToken { get; set; }
        public bool IsMSOAdmin { get; set; }
        public string BannedWordsJsonString { get; set; }
        public string EmailAPIToken { get; set; }
        public string StudentTheme { get; set; }
        public long SessionId { get; set; }
        public int IsSTS { get; set; }
    }
}