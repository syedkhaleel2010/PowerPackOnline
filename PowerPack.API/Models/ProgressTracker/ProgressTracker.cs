using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models
{
    public class ProgressTracker
    {
    }
    public class BindSteps
    {
        public string SYC_STEP { get; set; }

    }

    public class TopicTree
    {
        public long SYD_ID { get; set; }
        public long SYD_PARENT_ID { get; set; }
        public string SYD_DESCR { get; set; }


    }

    public class SubTerms
    {
        public int ID { get; set; }
        public string DESCRIPTION { get; set; }
        public bool LOCK_STATUS { get; set; }
        public int TERM_ID { get; set; }
        public string TERM_DESCRIPTION { get; set; }
        public int DISPLAY_ORDER { get; set; }
    }

    public class ProgressTrackerData
    {
        public long STU_ID { get; set; }
        public int OBJ_ID { get; set; }
        public string OBJ_VALUE { get; set; }
        public string TSM_ID { get; set; }
        public string FileCount { get; set; }
    }
    public class ProgressTrackerHeader
    {
        public int OBJ_ID { get; set; }
        public string OBJ_CODE { get; set; }
        public string OBJ_DESC { get; set; }
        public string OBJ_ENDDT { get; set; }
        public string TOPIC_ID { get; set; }
        public string TOPIC { get; set; }
        public string SUB_TOPIC { get; set; }
        public string STEPS { get; set; }
        public float OBJ_WIDTH { get; set; }
        public int SUBTOPIC_COLSPAN { get; set; }

        public float STEPS_WIDTH{ get; set; }

    }
    public class ProgressTrackerDropdown
    {
        public string CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string COLOR_CODE { get; set; }
        public int ORDER_SEQUENCE { get; set; }
        public bool IS_DROPDOWN { get; set; }
        public bool IsShowCodeAsHeader { get; set; }
    }

    public class PivotGrid
    {
        public string StudentName { get; set; }

        public string Grade { get; set; }

        public string Section { get; set; }

        public string Term { get; set; }

        public long StudentNumber { get; set; }
        public string Subjects { get; set; }
        public double AttainmentPercentage { get; set; }

        public string AttainmentDescription { get; set; }


    }


    public class ProgressAssessment
    {
        public long id { get; set; }
        public string Grade { get; set; }
        public string Code { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }
        public string Color { get; set; }

        public string Value { get; set; }
        public string Type { get; set; }
        public string DataMode { get; set; }
    }

    public class ProgressExpectation
    {
        public string Grade { get; set; }
        public string Code { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }
        public string Color { get; set; }

        public string Value { get; set; }

    }

    public class ProgressTrackerSettingMaster
    {

        public long DAM_ID { get; set; }
        public string DAM_DESCR  { get; set; }
        public string DAM_BSU_ID { get; set; }
        public string DAM_GRD_IDS { get; set; }
        public string DAM_ACD_ID { get; set; }
        public bool DAM_ShowCodeAsHeader { get; set; }
        public bool DAM_ShowAsDropdown { get; set; }
    }

    public class ProgressTrackerSettingDetails
    {

        public int DescriptorId { get; set; }
        public int DescriptorMasterId { get; set; }
        public string Descriptor_Descriptor { get; set; }
        public string Descriptor_Color_Code { get; set; }
        public int Descriptor_Order { get; set; }

        public string Descriptor_Code { get; set; }
        public string Descriptor_Value { get; set; }
        public string Descriptor_Type { get; set; }
        public string GradeIds { get; set; }
        public string DataMode { get; set; }
    }


    public class PTExpectationDetails
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ColorCode { get; set; }
        public double FromRange { get; set; }
        public double ToRange { get; set; }
        public int SubjectId { get; set; }
        public string Subject { get; set; }

    }


    public class PTExpectationSaver
    {

        public PTExpectationSaver()
        {
            objExpectation = new List<PTExpectationDetails>();
            objDeleteExpectation = new List<PTExpectationDetails>();
        }


        public List<PTExpectationDetails> objExpectation { get; set; }
        public List<PTExpectationDetails> objDeleteExpectation { get; set; }
    }

    public class PTSubjectMaster
    {
        public int SBM_ID { get; set; }

        public string SBM_DESCR { get; set; }


    }


}
