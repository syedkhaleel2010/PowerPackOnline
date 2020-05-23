using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PowerPack.Common.Models
{
    public class EventView
    {
        public int EventId { get; set; }
        public long SchoolId { get; set; }
        public long UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int DurationId { get; set; }
        public int EventCategoryId { get; set; }
        public string Title { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }
        public string EventTypeId { get; set; }
        public string ResourceFile { get; set; }
        //public HttpPostedFileBase ResourceFileUploade { get; set; }
        public string EventPriority { get; set; }
        public string Extension { get; set; }
        public string Icon { get; set; }
        public string FileName { get; set; }
        public bool IsTeacherVisible { get; set; }
        public string ColorCode { get; set; }
        public int EventRepeatTypeId { get; set; }
        public string EventRepeatTimes { get; set; }
        public bool IsCopyMessage { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long UpdatedBy { get; set; }
        public string Duration { get; set; }
        public string EventCategory { get; set; }
        public bool IsAddMode { get; set; }
        public string SelectedTeacherId { get; set; }
        public string DeselectedTeacherId { get; set; }
        public string SelectedStudentId { get; set; }
        public string DeselectedStudentId { get; set; }
        public string SelectedPlannerMemberId { get; set; }
        public string DeselectedPlannerMemberId { get; set; }
        public string ExternalEmails { get; set; }
        public IEnumerable<Common.Models.ListItem> UnAssignedMemberList { get; set; }
        public IEnumerable<Common.Models.ListItem> AssignedMemberList { get; set; }
        //public List<SelectListItem> TeacherList { get; set; }
        //public List<SelectListItem> SelectedTeacherList { get; set; }
        //public List<SelectListItem> StudentList { get; set; }
        //public List<SelectListItem> SelectedStudentList { get; set; }
        public List<EventUser> EventExternalUser { get; set; }
        public List<EventUser> EventUser { get; set; }

    }
    public class EventUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public bool IsRSVP { get; set; }
    }
}
