using SIMS.API.Models;
using SIMS.API.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SIMS.API.Helpers;

namespace SIMS.API.Services
{
    public class ProgressTrackerSettingService : IProgressTrackerSettingService
    {
        private readonly IProgressTrackerSettingRepository _ProgressTrackerSettingRepository;

        public ProgressTrackerSettingService(IProgressTrackerSettingRepository ProgressTrackerSettingRepository)
        {
            _ProgressTrackerSettingRepository = ProgressTrackerSettingRepository;
        }

        #region Made By Dhanaji
        #region Upload Objective
        public async Task<int> BulkUploadObjective(UploadObjectiveModel uploadObjectiveModel)
        {
            return await _ProgressTrackerSettingRepository.BulkUploadObjective(uploadObjectiveModel);
        }
        public async Task<IEnumerable<TopicDetail>> GetTopicDetailList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID, long SYD_ID)
        {
            return await _ProgressTrackerSettingRepository.GetTopicDetailList(BSU_ID, ACD_ID, TRM_ID, GRD_ID, SBG_ID, SYD_ID);
        }
        public async Task<IEnumerable<TopicObjective>> GetTopicObjectiveList(long SYD_ID)
        {
            return await _ProgressTrackerSettingRepository.GetTopicObjectiveList(SYD_ID);
        }
        public async Task<IEnumerable<TopicParent>> GetTopicParentList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID)
        {
            return await _ProgressTrackerSettingRepository.GetTopicParentList(BSU_ID, ACD_ID, TRM_ID, GRD_ID, SBG_ID);
        }
        public async Task<int> AddEditTopicDetails(TopicDetail topicDetail, string DATAMODE)
        {
            return await _ProgressTrackerSettingRepository.AddEditTopicDetails(topicDetail, DATAMODE);
        }
        public async Task<int> AddEditTopicObjective(TopicObjective topicObjective, string DATAMODE)
        {
            return await _ProgressTrackerSettingRepository.AddEditTopicObjective(topicObjective, DATAMODE);
        }
        #endregion 
        #endregion
    }
}
