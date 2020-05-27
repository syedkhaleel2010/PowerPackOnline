using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Models
{
    #region Made By Dhanaji
    public class UploadObjectiveModel
    {
        public UploadObjectiveModel()
        {
            ObjectiveExcelModel = new List<ObjectiveExcelModel>();
        }
        public long ACD_ID { get; set; }
        public long BSU_ID { get; set; }
        public long TRM_ID { get; set; }
        public string GRD_ID { get; set; }
        public long SBG_ID { get; set; }
        public int AGEBAND_ID { get; set; }
        public List<ObjectiveExcelModel> ObjectiveExcelModel { get; set; }
        public DataTable ObjectiveExcelDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("OBJ_ID", typeof(int));
                dt.Columns.Add("OBJ_CODE", typeof(string));
                dt.Columns.Add("OBJ_DESC", typeof(string));
                dt.Columns.Add("OBJ_START_DATE", typeof(DateTime));
                dt.Columns.Add("OBJ_END_DATE", typeof(DateTime));
                dt.Columns.Add("OBJ_LESSON_NO", typeof(int));
                dt.Columns.Add("SUBTOPIC_DESC", typeof(string));
                dt.Columns.Add("TOPIC_DESC", typeof(string));
                dt.Columns.Add("STEPS", typeof(string));
                int OBJ_ID = 1;

                ObjectiveExcelModel.ToList().ForEach(item =>
                {
                    dt.Rows.Add(OBJ_ID,
                                item.ObjectiveCode,
                                item.Objectives,
                                item.Start_Date,
                                item.End_Date,
                                item.No_of_Lessons,
                                item.Sub_Topic,
                                item.Topic,
                                item.Step
                               );
                    OBJ_ID++;
                });
                return dt;
            }
        }

    }
    public class ObjectiveExcelModel
    {
        public string Topic { get; set; }
        public string Sub_Topic { get; set; }
        public string ObjectiveCode { get; set; }
        public string Objectives { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public int No_of_Lessons { get; set; }
        public string Step { get; set; }
    }
    public class TopicDetail
    {
        public long SYD_ID { get; set; }
        public long Syllabus_ID { get; set; }
        public string Topic_Name { get; set; }
        public DateTime Topic_Start_Date { get; set; }
        public DateTime Topic_End_Date { get; set; }
        public string Topic_Parent { get; set; }
        public decimal Topic_Hours { get; set; }
        public string Topic_Description { get; set; }
        public string GradeId { get; set; }
        public long SubjectId { get; set; }
        public long TermId { get; set; }
        public long ParentID { get; set; }
        public long ACD_ID { get; set; }
        public long SchoolId { get; set; }
    }
    public class TopicObjective
    {
        public long SYD_ID { get; set; }
        public long ObjectiveId { get; set; }
        public string Objective_Code { get; set; }
        public string Objective_Description { get; set; }
        public DateTime Objective_Start_Date { get; set; }
        public DateTime Objective_End_Date { get; set; }
        public int Objective_Lesson { get; set; }
        public int TermId { get; set; }
        public string GradeId { get; set; }
        public int SubjectGradeId { get; set; }
        public int ACD_ID { get; set; }
        public long AgeBand { get; set; }
        public string Objective_Step { get; set; }
    }
    public class TopicParent
    {
        public long TopicParentId { get; set; }
        public string TopicParent_Description { get; set; }
    }
    #endregion
}
