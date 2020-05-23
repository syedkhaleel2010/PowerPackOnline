using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models
{
    public class CurriculumRole
    {
        public int Id { get; set; }
        public int BSU_CLM_ID { get; set; }
        public bool IsSuperUser { get; set; }
        public int ACD_ID { get; set; }
        public long GSA_ID { get; set; }

        public int NEXT_ACD_ID { get; set; }
        public int PREV_ACD_ID { get; set; }
    }

    public class Curriculum
    {
        public int ACD_ID { get; set; }
        public string CLM_ID { get; set; }
        public string CLM_DESCR { get; set; }
    }
}
