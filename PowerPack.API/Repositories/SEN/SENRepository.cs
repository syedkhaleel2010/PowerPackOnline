using Dapper;
using DbConnection;
using Microsoft.Extensions.Configuration;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PowerPack.Common.Helpers;
using System.IO;

namespace SIMS.API.Repositories
{
    public class SENRepository : SqlRepository<SEN>, ISENRepository
    {
        private readonly IConfiguration _config;

        public SENRepository(IConfiguration configuration) : base(configuration)
        {
            _config = configuration;
        }

        public async Task<IEnumerable<BasicDetails>> Get_studentInclusionList(string BSU_ID, string ACD_ID, string GRD_ID, string SCT_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.String);
                parameters.Add("@ACD_ID", ACD_ID, DbType.String);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@SCT_ID", SCT_ID, DbType.String);
                return await conn.QueryAsync<BasicDetails>("SIMS.GET_SEN_ACE_STUDENTS", parameters, null, null, CommandType.StoredProcedure);
            }
        }


        public async Task<IEnumerable<BasicDetails>> Get_studentInclusionAll(string BSU_ID, string ACD_ID, string GRD_ID, string SCT_ID)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BSU_ID", BSU_ID, DbType.String);
                parameters.Add("@ACD_ID", ACD_ID, DbType.String);
                parameters.Add("@GRD_ID", GRD_ID, DbType.String);
                parameters.Add("@SCT_ID", SCT_ID, DbType.String);
                return await conn.QueryAsync<BasicDetails>("SIMS.GET_SEN_ACE_STUDENTS_ALL", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public bool InsertBulkSEN(String stuIds)
        {
            var parameters = new DynamicParameters();
             
            parameters.Add("@STU_IDs", stuIds, DbType.String); 
            parameters.Add("@RETURN_VALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.INSERT_BULK_SEN_STUDENT", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("RETURN_VALUE") > 0;
            }
        }
        public bool updateSenStudent(String stuId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@STU_ID", stuId, DbType.String);
            parameters.Add("@RETURN_VALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.UPDATE_SEN_STUDENT", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("RETURN_VALUE") > 0;
            }
        }



        public async Task<IEnumerable<SEN_KHDA_MASTER>> Get_SEN_KHDA_MASTER()
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters(); 
                return await conn.QueryAsync<SEN_KHDA_MASTER>("SIMS.GET_SEN_KHDA_MASTER", parameters, null, null, CommandType.StoredProcedure);
            }
        }


        public async Task<KHDA_STUDENT> Get_KHDA_STUDENT(string stuId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", stuId, DbType.String); 
                return await conn.QueryFirstOrDefaultAsync<KHDA_STUDENT>("SIMS.GET_SEN_KHDA_PROFILE", parameters, null, null, CommandType.StoredProcedure);
            }
        }


        public async Task<IEnumerable<SEN_KHDA_TRANS>> Get_SEN_KHDA_TRANS_LIST(string stuId)
        {
            using (var conn = GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@STU_ID", stuId, DbType.String); 
                return await conn.QueryAsync<SEN_KHDA_TRANS>("SIMS.GET_SEN_KHDA_TRANS", parameters, null, null, CommandType.StoredProcedure);
            }
        }
        public bool SaveSENKHDA(KHDA mainModel, string uGUID,string filePathConfig)
        {
             
            var parameters = new DynamicParameters();


            var SKP_ID = mainModel.KHDA_STUDENT.SKP_ID;

            parameters.Add("@SKP_ID", SKP_ID, DbType.Int32, ParameterDirection.InputOutput);
            parameters.Add("@RETURN_VALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            parameters.Add("@SKP_STU_ID", mainModel.KHDA_STUDENT.SKP_STU_ID, DbType.String);
            parameters.Add("@SKP_SEN", mainModel.KHDA_STUDENT.SKP_SEN, DbType.Boolean);
            parameters.Add("@SKP_WAVE", mainModel.KHDA_STUDENT.SKP_WAVE, DbType.Int64);
            parameters.Add("@SKP_ELL_WAVE", mainModel.KHDA_STUDENT.SKP_ELL_WAVE, DbType.Int32);
            parameters.Add("@SKP_COMMENTS", mainModel.KHDA_STUDENT.SKP_COMMENTS, DbType.String);
            parameters.Add("@SKP_ADDED_BY", mainModel.KHDA_STUDENT.SKP_ADDED_BY, DbType.String);
            parameters.Add("@SKP_MODIFED_BY", mainModel.KHDA_STUDENT.SKP_MODIFED_BY, DbType.String);
            using (var conn = GetOpenConnection())
            {
                conn.Query<int>("SIMS.INSERT_SEN_KHDA_PROFILE", parameters, commandType: CommandType.StoredProcedure);
                SKP_ID = parameters.Get<int>("SKP_ID");
                if (parameters.Get<int>("RETURN_VALUE") != 0)
                {
                    return false;
                }
                
            }
            if (SKP_ID > 0 && mainModel.SEN_KHDA_TRANS_LIST !=null)
            {
                
                foreach (var item in mainModel.SEN_KHDA_TRANS_LIST)
                {
                    Int32 SKT_ID = item.SKT_ID.Value;
                    var parametersTrans = new DynamicParameters();
                    parametersTrans.Add("@SKT_ID", SKT_ID, DbType.Int32, ParameterDirection.InputOutput);
                    parametersTrans.Add("@SKT_SKP_ID", SKP_ID, DbType.Int32);
                    parametersTrans.Add("@SKT_SKM_ID", item.SKT_SKM_ID, DbType.Int32);
                    parametersTrans.Add("@SKT_STU_ID", item.SKT_STU_ID, DbType.String);
                    parametersTrans.Add("@SKT_COMMENT", item.SKT_COMMENT, DbType.String);
                    parametersTrans.Add("@SKT_ACTION_TAKEN", item.SKT_ACTION_TAKEN, DbType.String);
                    parametersTrans.Add("@SKT_ADDED_BY", item.SKT_ADDED_BY, DbType.String);
                    parametersTrans.Add("@SKT_MODIFED_BY", item.SKT_MODIFED_BY, DbType.String);
                    parametersTrans.Add("@SKT_ISACTIVE", item.SKT_ISACTIVE, DbType.Boolean);
                    parametersTrans.Add("@SKT_IS_CHECKED", item.SKT_IS_CHECKED, DbType.Boolean);
                    using (var conn = GetOpenConnection())
                    {
                        conn.Query<int>("SIMS.SAVE_SEN_KHDA_TRANS", parametersTrans, commandType: CommandType.StoredProcedure);
                        SKT_ID = parametersTrans.Get<int>("SKT_ID");

                        if (SKT_ID > 0)
                        {
                            string filePath = filePath = filePathConfig + "/KHDA/TEMP/" + uGUID + "/" + item.TABLE_ID + "/" + item.ROW_NUM;
                            if (Directory.Exists(filePath))
                            {
                                string[] files = Directory.GetFiles(filePath);

                                foreach (string file in files)
                                {
                                    string filePathDistination =  filePathConfig + "/KHDA/Final/" + SKP_ID+ "/" + SKT_ID;
                                    if (!Directory.Exists(filePathDistination))
                                    {                                         
                                        Directory.CreateDirectory(filePathDistination);
                                    }

                                    FileInfo mFile = new FileInfo(file);
                                    // to remove name collisions
                                    if (new FileInfo(filePathDistination + "\\" + mFile.Name).Exists == false)
                                    {
                                        mFile.MoveTo(filePathDistination + "\\" + mFile.Name);
                                    }
                                }
                                Directory.Delete(filePath);
                            }
                        }

                    }
                }
            }

            return true; 
        }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override  Task<IEnumerable<SEN>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override  Task<SEN> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

      

        public override void InsertAsync(SEN entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(SEN entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
