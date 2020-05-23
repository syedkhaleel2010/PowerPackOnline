using SIMS.API.Repositories;
using SIMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Xml.Linq;

namespace SIMS.API.Services
{
    public class ProgressTrackerService : IProgressTrackerService
    {
        private readonly IProgressTrackerRepository _ProgressTrackerRepository;

        public ProgressTrackerService(IProgressTrackerRepository ProgressTrackerRepository)
        {
            _ProgressTrackerRepository = ProgressTrackerRepository;
        }

        public async Task<IEnumerable<BindSteps>> BindSteps(long ACD_ID, string GRD_ID, long SBG_ID, string SYD_ID)
        {
            return await _ProgressTrackerRepository.BindSteps(ACD_ID, GRD_ID, SBG_ID, SYD_ID);
        }

        public async Task<IEnumerable<SubTerms>> BindSubTerm(long BSU_ID, long ACD_ID)
        {
            return await _ProgressTrackerRepository.BindSubTerm(BSU_ID, ACD_ID);
        }

        public async Task<IEnumerable<TopicTree>> BindTopicTree(long TRM_ID, long SBG_ID)
        {
            return await _ProgressTrackerRepository.BindTopicTree(TRM_ID, SBG_ID);
        }

        public async Task<IEnumerable<ProgressTrackerData>> GET_PROGRESS_TRACKER_DATA(long SBG_ID, string TOPIC_ID, long TSM_ID, long SGR_ID)
        {
            return await _ProgressTrackerRepository.GET_PROGRESS_TRACKER_DATA(SBG_ID, TOPIC_ID, TSM_ID, SGR_ID);
        }

        public async Task<IEnumerable<ProgressTrackerHeader>> GET_PROGRESS_TRACKER_HEADERS(long SBG_ID, string TOPIC_ID, long AGE_BAND_ID, string STEPS, long TSM_ID)
        {
            return await _ProgressTrackerRepository.GET_PROGRESS_TRACKER_HEADERS(SBG_ID, TOPIC_ID, AGE_BAND_ID, STEPS, TSM_ID);
        }

        public bool HAS_AgeBand(long BSU_ID, long ACD_ID, string GRD_ID)
        {
            return _ProgressTrackerRepository.HAS_AgeBand(BSU_ID, ACD_ID, GRD_ID);
        }

        public bool HAS_STEPS(long BSU_ID, long ACD_ID, string GRD_ID)
        {
            return _ProgressTrackerRepository.HAS_STEPS(BSU_ID, ACD_ID, GRD_ID);
        }
        public async Task<IEnumerable<ProgressTrackerDropdown>> BindProgressTrackerDropdown(long BSU_ID, string GRD_ID)
        {
            return await _ProgressTrackerRepository.BindProgressTrackerDropdown(BSU_ID, GRD_ID);
        }

        public bool SaveProgressTrackerData(int ACD_ID, string GRD_ID, int SBG_ID, XElement STC_XML, DateTime STC_UPDATEDATE, string STC_USER, int SYD_ID)
        {
            return _ProgressTrackerRepository.SaveProgressTrackerData(ACD_ID, GRD_ID, SBG_ID, STC_XML, STC_UPDATEDATE, STC_USER, SYD_ID);
        }

        public async Task<IEnumerable<PivotGrid>> PivotGridList(int acdId)
        {
            return await _ProgressTrackerRepository.PivotGridList(acdId);
        }

        public bool SaveProgressAssessmentSetting(long DAM_ID, string DAM_DESCR, string DAM_GRD_IDS, string DAM_BSU_ID, long DAM_ACD_ID, string DATAMODE, bool DAM_ShowCodeAsHeader, bool DAM_ShowAsDropdown, List<ProgressTrackerSettingDetails> objDescriptorData)
        {
            return _ProgressTrackerRepository.SaveProgressAssessmentSetting(DAM_ID, DAM_DESCR, DAM_GRD_IDS, DAM_BSU_ID, DAM_ACD_ID, DATAMODE, DAM_ShowCodeAsHeader, DAM_ShowAsDropdown, objDescriptorData);
        }

        public Task<IEnumerable<ProgressTrackerSettingMaster>> GetProgressTrackerMasterSetting(string acdId)
        {
            return _ProgressTrackerRepository.GetProgressTrackerMasterSetting(acdId);
        }
        public Task<ProgressTrackerSettingMaster> BindProgressTrackerMasterSetting(long ACD_ID, long BSU_ID, string GRD_ID)
        {
            return _ProgressTrackerRepository.BindProgressTrackerMasterSetting(ACD_ID, BSU_ID, GRD_ID);
        }

        public Task<IEnumerable<ProgressTrackerSettingDetails>> GetProgressTrackerDetailSetting(long DAM_ID, string DAM_TYPE)
        {
            return _ProgressTrackerRepository.GetProgressTrackerDetailSetting(DAM_ID, DAM_TYPE);
        }

        public Task<IEnumerable<PTExpectationDetails>> GetPTExceptionSetting(int DAM_ID)
        {
            return _ProgressTrackerRepository.GetPTExceptionSetting(DAM_ID);
        }

        public bool AddEditExpectationDetails(int DAM_ID, List<PTExpectationDetails> objExpectation, List<PTExpectationDetails> objDeleteExpectation)
        {
            return _ProgressTrackerRepository.AddEditExpectationDetails(DAM_ID, objExpectation, objDeleteExpectation);
        }

        public Task<IEnumerable<PTSubjectMaster>> BindSubjectMasterByGrade(int ACD_ID, string BSU_ID, string GRD_ID)
        {
            return _ProgressTrackerRepository.BindSubjectMasterByGrade(ACD_ID, BSU_ID, GRD_ID);
        }
    }
}
