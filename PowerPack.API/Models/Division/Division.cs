using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Models
{
    public class DivisionDetails
    {
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string GradeList { get; set; }
        public string CREATED_BY { get; set; }
        public long BSU_ID { set; get; }

        public string DataMode { get; set; }

    }
}
