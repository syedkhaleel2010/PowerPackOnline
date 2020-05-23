using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Models
{
    public class BehaviourSetup
    {
        public long MainCategoryID { set; get; }
        public long SubCategoryID { set; get; }
        public string GRD_ID { get; set; }
        public long BSU_ID { set; get; }
        public string MainCategoryName { set; get; }
        public string SubCategoryName { set; get; }
        public string GradeDisplay { set; get; }
        public decimal CategoryScore { set; get; }
        public string CategoryImagePath { get; set; }
        public bool IsDeletedImage { get; set; }
        public bool HasLevel { get; set; }
        public string CategoryLevel { get; set; }
        public IEnumerable<CategoryLevel> CategoryLevelList { get; set; }
    }

    public class Designations
    {
        public long DesignationId { get; set; }
        public string Designation { get; set; }
    }
    public class DesignationsRouting
    {
        public long DesignationRoutingId { get; set; }
        public long DesignationFromId { get; set; }
        public string DesignationFrom { get; set; }
        public long DesignationToId { get; set; }
        public string DesignationTo { get; set; }
        public long DesignationSchoolId { get; set; }
        public int DesignationOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class DesignationsRoutingCUD
    {
        public List<DesignationsRouting> Routings { get; set; }
        public DataTable RoutingsDT
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("BM_ROUT_ID", typeof(long));
                dt.Columns.Add("BM_FROM_DESIGID", typeof(long));
                dt.Columns.Add("BM_TO_DESIGID", typeof(long));
                dt.Columns.Add("BSU_ID", typeof(long));
                dt.Columns.Add("BM_FWD_ORDER", typeof(long));
                dt.Columns.Add("Is_Active", typeof(long));
                Routings.ForEach(x =>
                {
                    DataRow dr = dt.NewRow();
                    dr["BM_ROUT_ID"] = x.DesignationRoutingId;
                    dr["BM_FROM_DESIGID"] = x.DesignationFromId;
                    dr["BM_TO_DESIGID"] = x.DesignationToId;
                    dr["BSU_ID"] = x.DesignationSchoolId;
                    dr["BM_FWD_ORDER"] = x.DesignationOrder;
                    dr["Is_Active"] = x.IsActive;
                    dt.Rows.Add(dr);
                });
                return dt;
            }
        }
    }

    public class CertificateScheduling
    {
        public long CertificateSchedulingId { get; set; }
        public string Description { get; set; }
        public int? Points { get; set; }
        public string CertificateType { get; set; }
        public long CertificateTypeId { get; set; }
        public long AcademicYearId { get; set; }
        public bool IsEmail { get; set; }
        public bool IsPrint { get; set; }
        public bool IsEmailOther { get; set; }
        public string EmailOtherStaffId { get; set; }
        public int? ScheduleType { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class CategoryLevel
    {
        public long Mapping_ID { get; set; }
        public long Level_ID { get; set; }
        public string Level_Description { get; set; }
        public int Level_Score { get; set; }
        public bool IsChecked { get; set; }
    }

}
