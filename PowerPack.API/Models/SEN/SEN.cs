using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Models
{
    public class SEN
    {
        public SEN()
        {
            studentInclusionList = new List<BasicDetails>();
            studentInclusionAll = new List<BasicDetails>();
        }
        public IEnumerable<BasicDetails> studentInclusionList { get; set; }

        public IEnumerable<BasicDetails> studentInclusionAll { get; set; }

    }

    public class KHDA
    {
        public KHDA()
        {
            STudentDetails = new BasicDetails();
            KHDA_STUDENT = new KHDA_STUDENT();
            SEN_KHDA_MASTER_LIST = new List<SEN_KHDA_MASTER>();
            SEN_KHDA_TRANS_LIST = new List<SEN_KHDA_TRANS>();
        }
        public BasicDetails STudentDetails { get; set; }
        public KHDA_STUDENT KHDA_STUDENT { get; set; }

        public IEnumerable<SEN_KHDA_MASTER> SEN_KHDA_MASTER_LIST { get; set; }

        public IEnumerable<SEN_KHDA_TRANS> SEN_KHDA_TRANS_LIST { get; set; }

    }
    public class SEN_KHDA_MASTER
    {
        public int SKM_ID { get; set; }
        public string SKM_DESC { get; set; }
    }
    public class KHDA_STUDENT
    {
        public int SKP_ID { get; set; }
        public string SKP_STU_ID { get; set; }
        public bool? SKP_SEN { get; set; }
        public int? SKP_WAVE { get; set; }
        public int? SKP_ELL_WAVE { get; set; }
        public DateTime? SKP_ADDED_ON { get; set; }
        public DateTime? SKP_MODIFIED_ON { get; set; }
        public string SKP_ADDED_BY { get; set; }
        public string SKP_MODIFED_BY { get; set; }
        public string SKP_COMMENTS { get; set; }

    }


    public class SEN_KHDA_TRANS
    {
        public int? SKT_ID { get; set; }
        public int SKT_SKP_ID { get; set; }
        public int SKT_SKM_ID { get; set; }
        public string SKT_STU_ID { get; set; }
        public string SKT_COMMENT { get; set; }
        public string SKT_ACTION_TAKEN { get; set; }
        public DateTime SKT_ADDDED_ON { get; set; }
        public DateTime SKT_MODIFIED_ON { get; set; }
        public bool SKT_ISACTIVE { get; set; }
        public string SKT_ADDED_BY { get; set; }
        public string SKT_MODIFED_BY { get; set; }

        public bool SKT_IS_CHECKED { get; set; }
        public string TABLE_ID { get; set; }
        public int ROW_NUM { get; set; }
    }

}