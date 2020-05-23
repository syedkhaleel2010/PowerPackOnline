using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPack.Common.Models
{
    public class TerminologyEditorView
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public long SchoolId { get; set; }
        public string OldTerm { get; set; }
        public string NewTerm { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
