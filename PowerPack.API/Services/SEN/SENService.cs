using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SIMS.API.Services
{
    public class SENService : ISENService
    {
        private readonly ISENRepository _SENRepository;

        public SENService(ISENRepository SENRepository)
        {
            _SENRepository = SENRepository;
        }
        public async Task<IEnumerable<BasicDetails>> Get_studentInclusionList(string BSU_ID, string ACD_ID, string GRD_ID, string SCT_ID)
        {
            return await _SENRepository.Get_studentInclusionList(BSU_ID, ACD_ID, GRD_ID, SCT_ID);
        }

        public async Task<IEnumerable<BasicDetails>> Get_studentInclusionAll(string BSU_ID, string ACD_ID, string GRD_ID, string SCT_ID)
        {
            return await _SENRepository.Get_studentInclusionAll(BSU_ID, ACD_ID, GRD_ID, SCT_ID);
        }

        public bool InsertBulkSEN(String stuIds)
        {
            return _SENRepository.InsertBulkSEN(stuIds);
        }

        public bool updateSenStudent(String stuId) {
            return _SENRepository.updateSenStudent(stuId);
        }


        public async Task<IEnumerable<SEN_KHDA_MASTER>> Get_SEN_KHDA_MASTER()
        {
            return await _SENRepository.Get_SEN_KHDA_MASTER();
        }

        public async Task<KHDA_STUDENT> Get_KHDA_STUDENT(string stuId)
        {
            return await _SENRepository.Get_KHDA_STUDENT(stuId);
        }

        public async Task<IEnumerable<SEN_KHDA_TRANS>> Get_SEN_KHDA_TRANS_LIST(string stuId)
        {
            return await _SENRepository.Get_SEN_KHDA_TRANS_LIST(stuId);
        }

        public bool SaveSENKHDA(KHDA mainModel, string uGUID,string filePath)
        {
            return _SENRepository.SaveSENKHDA(mainModel, uGUID, filePath);
        }

    }
}
