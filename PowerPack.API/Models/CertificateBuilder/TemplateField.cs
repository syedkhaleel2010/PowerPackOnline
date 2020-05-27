using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Models.CertificateBuilder
{
    public class TemplateField
    {
        public TemplateField()
        {

        }

        public TemplateField(Int64 _TemplateFieldId)
        {
            TemplateFieldId = _TemplateFieldId;
        }

        public Int64 TemplateFieldId { get; set; }
        public Int64 TemplateId { get; set; }
        public string Field { get; set; }
        public string Placeholder { get; set; }
        public bool IsLabel { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int CertificateColumnId { get; set; }
    }

    public class TemplateFieldMapping
    {
        public int CertificateColumnId { get; set; }
        public string ColumnName { get; set; }
        public string ColumnData { get; set; }
        public string FieldName { get; set; }
        public string PlaceHolder { get; set; }
        public string CertificateTitle { get; set; }
        public short CertificateTypeId { get; set; }
        public string FileName { get; set; }
        public string ImageData { get; set; }
        public long UserId { get; set; }
    }
}
