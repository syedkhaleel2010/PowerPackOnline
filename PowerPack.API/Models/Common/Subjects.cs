using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Models
{
    public class Subjects
    {
        public int SBG_ID { get; set; }
        public string SBG_DESCR { get; set; }
        public string SBG_PARENTS { get; set; }
        public string OPT { get; set; }
        public string GRM_DISPLAY { get; set; }
        public string SBG_PARENTS_SHORT { get; set; }
        public string SBG_GRD_ID { get; set; }
        public int SSD_SGR_ID { get; set; }
    }
    public class SubjectGroups
    {
        public int SGR_ID { get; set; }
        public string SGR_DESCR { get; set; }
        public string SBM_DESCR { get; set; }

    }

}


