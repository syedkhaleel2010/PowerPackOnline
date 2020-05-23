using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;

namespace SIMS.API.Repositories
{
    public class BehaviourSetupRepository : SqlRepository<BehaviourSetup>, IBehaviourSetupRepository
    {
        private readonly IConfiguration _config;

        public BehaviourSetupRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }
        #region Behaviour Setup
        public async Task<IEnumerable<BehaviourSetup>> GetSubCategoryList(long CategoryID, long BSU_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.Int64);
                parameters.Add("@CATEGORYHRID", CategoryID, DbType.Int64);
                return await conn.QueryAsync<BehaviourSetup>("SIMS.BehaviourSetup_GetSubCategoryList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<int> SaveSubCategory(BehaviourSetup behaviourSetup, string DATAMODE)
        {
            using (var conn = GetOpenConnection())
            {

                var parameters = new DynamicParameters();
                parameters.Add("@MainCategoryID", behaviourSetup.MainCategoryID, DbType.Int64);
                parameters.Add("@SubCategoryID", behaviourSetup.SubCategoryID, DbType.Int64);
                parameters.Add("@GRD_ID", behaviourSetup.GRD_ID, DbType.String);
                parameters.Add("@BSU_ID", behaviourSetup.BSU_ID, DbType.String);
                parameters.Add("@SubCategoryName", behaviourSetup.SubCategoryName, DbType.String);
                parameters.Add("@CategoryScore", behaviourSetup.CategoryScore, DbType.Decimal);
                parameters.Add("@CategoryImagePath", behaviourSetup.CategoryImagePath, DbType.String);
                parameters.Add("@IsDeletedImage", behaviourSetup.IsDeletedImage, DbType.String);
                parameters.Add("@DATAMODE", DATAMODE, DbType.String);
                parameters.Add("@CategoryLevel",ConvertToXML(behaviourSetup.CategoryLevelList),DbType.String);
                parameters.Add("@HasLevel", behaviourSetup.HasLevel,DbType.Boolean);
                parameters.Add("@IsDeletedImage", behaviourSetup.IsDeletedImage, DbType.String);
                parameters.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<int>("SIMS.BehaviourSetup_SaveSubCategory", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<int>("output");
            }
        }
        #endregion

        #region Action Hierarchy
        public async Task<IEnumerable<Designations>> GetDesignations(long schoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SchoolId", schoolId, DbType.String);
                return await conn.QueryAsync<Designations>("SIMS.GetDesignationBySchoolId", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<DesignationsRouting>> GetDesignationsRoutings(long schoolId, long? designationFrom)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SchoolId", schoolId, DbType.Int64);
                parameters.Add("@DesignationId", designationFrom, DbType.Int64);
                return await conn.QueryAsync<DesignationsRouting>("SIMS.GetDesignationRoutingBySchool", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<DesignationsRouting>> DesignationBySchoolCUD(DesignationsRoutingCUD designationsRouting)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DesignationDT", designationsRouting.RoutingsDT, DbType.Object);
                return await conn.QueryAsync<DesignationsRouting>("SIMS.DesignationBySchoolCUD", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        #endregion

        #region Built In Functions
        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override Task<IEnumerable<BehaviourSetup>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<BehaviourSetup> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void InsertAsync(BehaviourSetup entity)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void UpdateAsync(BehaviourSetup entityToUpdate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Certificate Schedule
        public async Task<IEnumerable<CertificateScheduling>> GetCertificateSchedulings(long? CertificateSchedulingId, long? academicYear, long? schoolId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CertificateSchedulingId", CertificateSchedulingId, DbType.Int64);
                parameters.Add("@AcademicYearId", academicYear, DbType.Int64);
                parameters.Add("@SchoolId", schoolId, DbType.Int64);
                return await conn.QueryAsync<CertificateScheduling>("SIMS.CRB_GetCertificateScheduling", parameters, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<long> CertificateSchedulingCUD(CertificateScheduling certificateScheduling)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CertificateSchedulingId", certificateScheduling.CertificateSchedulingId);
                parameters.Add("@Description", certificateScheduling.Description);
                parameters.Add("@Points", certificateScheduling.Points);
                parameters.Add("@CertificateType", certificateScheduling.CertificateTypeId);
                parameters.Add("@AcademicYearId", certificateScheduling.AcademicYearId);
                parameters.Add("@IsEmail", certificateScheduling.IsEmail);
                parameters.Add("@IsPrint", certificateScheduling.IsPrint);
                parameters.Add("@IsEmailOther", certificateScheduling.IsEmailOther);
                parameters.Add("@EmailOtherStaffId", certificateScheduling.EmailOtherStaffId);
                parameters.Add("@ScheduleType", certificateScheduling.ScheduleType);
                parameters.Add("@CreatedBy", certificateScheduling.CreatedBy);
                parameters.Add("@IsActive", certificateScheduling.IsActive);
                parameters.Add("@output", dbType: DbType.Int64, direction: ParameterDirection.Output);
                await conn.QueryFirstOrDefaultAsync<long>("SIMS.CRB_CertificateSchedulingCUD", parameters, null, null, CommandType.StoredProcedure);
                return parameters.Get<long>("output");
            }
        }
        #endregion

        #region Category Level
        public async Task<IEnumerable<CategoryLevel>> GetCategoryLevel(long SubCategoryID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SubCategoryID", SubCategoryID, DbType.Int64);
                return await conn.QueryAsync<CategoryLevel>("SIMS.BehaviourSetup_GetLevelList", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        // By using this method we can convert datatable to xml
        public string ConvertToXML<T>(IEnumerable<T> items)
        {
            if(items == null)
            {
                return "";
            }
            DataTable dt = ToDataTable(items);
            MemoryStream str = new MemoryStream();
            dt.WriteXml(str, true);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            return (xmlstr);
        }
        /// <summary>
        /// Convert a List{T} to a DataTable.
        /// </summary>
        private DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }


            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }
           
        
    return tb;
        }

        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        #endregion
    }
}
