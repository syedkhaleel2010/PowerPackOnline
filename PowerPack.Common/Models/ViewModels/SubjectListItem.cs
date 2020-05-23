using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PowerPack.Common.Models
{
    public class SubjectListItem
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class SchoolGroupListModel
    {
        public long SelectedDropdownItem { get; set; }
        public IEnumerable<SelectListItem> DropdownList { get; set; }
    }
    public class AcademicYearList
    {
        public int AcademicYearId { get; set; }
        public string AcademicYear { get; set; }
    }
    public class AcademicYearListModel
    {
        public long SelectedDropdownItem { get; set; }
        public IEnumerable<AcademicYearList> DropdownList { get; set; }
    }
}
