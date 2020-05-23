using DbConnection;
using SIMS.API.Models;
using PowerPack.Common.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Xml.Linq;

namespace SIMS.API.Repositories
{
    public interface IProgressTrackerRepository
    {
        bool HAS_STEPS(long BSU_ID, long ACD_ID, string GRD_ID);
        bool HAS_AgeBand(long BSU_ID, long ACD_ID, string GRD_ID);
        Task<IEnumerable<BindSteps>> BindSteps(long ACD_ID, string GRD_ID, long SBG_ID, string SYD_ID);

        Task<IEnumerable<TopicTree>> BindTopicTree(long TRM_ID, long SBG_ID);

        Task<IEnumerable<SubTerms>> BindSubTerm(long BSU_ID,long ACD_ID);
        Task<IEnumerable<ProgressTrackerHeader>> GET_PROGRESS_TRACKER_HEADERS(long SBG_ID, string TOPIC_ID,long AGE_BAND_ID,string STEPS, long TSM_ID);
        Task<IEnumerable<ProgressTrackerData>> GET_PROGRESS_TRACKER_DATA(long SBG_ID, string TOPIC_ID, long TSM_ID, long SGR_ID);
        Task<IEnumerable<ProgressTrackerDropdown>> BindProgressTrackerDropdown(long BSU_ID, string GRD_ID);

        bool SaveProgressTrackerData(int ACD_ID, string GRD_ID, int SBG_ID, XElement STC_XML, DateTime STC_UPDATEDATE, string STC_USER,int SYD_ID );

        Task<IEnumerable<PivotGrid>> PivotGridList(int acdId);

        bool SaveProgressAssessmentSetting(long DAM_ID, string DAM_DESCR, string DAM_GRD_IDS, string DAM_BSU_ID, long DAM_ACD_ID, string DATAMODE, bool DAM_ShowCodeAsHeader, bool DAM_ShowAsDropdown, List<ProgressTrackerSettingDetails> objDescriptorData);
        Task<IEnumerable<ProgressTrackerSettingMaster>> GetProgressTrackerMasterSetting(string acdId);
        Task<ProgressTrackerSettingMaster> BindProgressTrackerMasterSetting(long ACD_ID,long BSU_ID,string GRD_ID);

        Task<IEnumerable<ProgressTrackerSettingDetails>> GetProgressTrackerDetailSetting(long DAM_ID,string DAM_TYPE);

        Task<IEnumerable<PTExpectationDetails>> GetPTExceptionSetting(int DAM_ID);


        bool AddEditExpectationDetails(int DAM_ID,List<PTExpectationDetails> objExpectation, List<PTExpectationDetails> objDeleteExpectation);

        Task<IEnumerable<PTSubjectMaster>> BindSubjectMasterByGrade(int ACD_ID, string BSU_ID, string GRD_ID);

    }
}
