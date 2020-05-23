using PowerPack.Common.ViewModels;
using PowerPack.Models;
using PowerPack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Models
{
    public class ParentView : User
    {
        public ParentView()
        {
            ChildIds = new List<int>();
            ChildNames = new List<string>();
            Childs = new List<Student>();
            StudentDetails = new List<StudentDetail>();
            studentDetail = new StudentDetail();
        }
        public User User { get; set; }
        public List<StudentDetail> StudentDetails { get; set; }
        public List<Student> Childs { get; set; }
        public List<int> ChildIds { get; set; }
        public List<string> ChildNames { get; set; }
        public List<AssignmentStudentDetails> Assignments { get; set; }
        public int PendingAssignments { get; set; }
        public int CompletedAssignments { get; set; }
        public StudentDetail studentDetail { get; set; }
        public string encriptedStudentId { get; set; }
    }
}
