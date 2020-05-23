using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models.CertificateBuilder
{
    public class Template
    {
        public Template()
        {
            TemplateFields = new List<TemplateField>();
        }

        public Template(Int64 _templateId)
        {
            TemplateId = _templateId;
            TemplateFields = new List<TemplateField>();
        }

        public Int64 TemplateId { get; set; }
        public Int64 SchoolId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TemplateType { get; set; }
        public string Period { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsStudentAssigned { get; set; }
        public List<TemplateField> TemplateFields { get; set; }
        public string JSONFileUrl { get; set; }
        public bool IsApprovalRequired { get; set; }
        public bool CanApproveTemplate { get; set; }
        public bool IsRejected { get; set; }
        public bool IsDeletable { get; set; }
        public string RejectedComment { get; set; }
        public int DivisionId { get; set; }
    }
}
