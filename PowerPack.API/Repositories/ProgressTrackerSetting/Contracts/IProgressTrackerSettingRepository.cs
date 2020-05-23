using DbConnection;
using PowerPack.Common.Enums;
using SIMS.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.API.Repositories
{
    public interface IProgressTrackerSettingRepository
    {
        #region Made By Dhanaji       
        Task<int> BulkUploadObjective(UploadObjectiveModel uploadObjectiveModel);
        Task<IEnumerable<TopicDetail>> GetTopicDetailList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID, long SYD_ID);
        Task<IEnumerable<TopicObjective>> GetTopicObjectiveList(long SYD_ID);
        Task<IEnumerable<TopicParent>> GetTopicParentList(long BSU_ID, long ACD_ID, long TRM_ID, string GRD_ID, long SBG_ID);
        Task<int> AddEditTopicDetails(TopicDetail topicDetail, string DATAMODE);
        Task<int> AddEditTopicObjective(TopicObjective topicObjective, string DATAMODE);
        #endregion
    }
}
