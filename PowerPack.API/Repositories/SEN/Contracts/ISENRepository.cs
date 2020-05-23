﻿using DbConnection;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Repositories
{
    public interface ISENRepository : IGenericRepository<SEN>
    { 
        Task<IEnumerable<BasicDetails>> Get_studentInclusionList(string BSU_ID, string ACD_ID, string GRD_ID, string SCT_ID);
        Task<IEnumerable<BasicDetails>> Get_studentInclusionAll(string BSU_ID, string ACD_ID, string GRD_ID, string SCT_ID);

        bool InsertBulkSEN(String stuIds);
        bool updateSenStudent(String stuId);

        Task<IEnumerable<SEN_KHDA_MASTER>> Get_SEN_KHDA_MASTER();

        Task<KHDA_STUDENT> Get_KHDA_STUDENT(string stuId);
        Task<IEnumerable<SEN_KHDA_TRANS>> Get_SEN_KHDA_TRANS_LIST(string stuId);

        bool SaveSENKHDA(KHDA mainModel, string uGUID,string filePath);
    }
}
