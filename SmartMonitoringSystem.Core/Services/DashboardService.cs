using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.Domain.RepositoryContracts;
using SmartMonitoringSystem.Core.DTO;
using SmartMonitoringSystem.Core.ServiceContracts;
using System.Data;

namespace SmartMonitoringSystem.Core.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<List<MemberResponse>> GetAllMembers()
        {
            List<Member> memberList = await _dashboardRepository.GetAllMembers();
            return memberList.Select(member => member.ToMemberResponse()).ToList();
        }

        public async Task<UserProfileResponse> GetProfileByUserID(int userID)
        {
            var profile = await _dashboardRepository.GetProfileByUserID(userID);
            return profile.ToUserProfile();
        }

        public async Task<List<PhaseSummaryDetailsResponse>> GetSummaryDetailsByPhaseID(int phaseID)
        {
            List<PhaseSummaryDetails> phaseSummaryDetails = await _dashboardRepository.GetSummaryDetailsByPhaseID(phaseID);
            return phaseSummaryDetails.Select(options => options.ToPhaseSummaryDetailsResponse()).ToList();
        }

        public async Task<List<PhaseResponse>> GetAllPhases()
        {
            List<BaySummaryDetails> phaseList = await _dashboardRepository.GetAllPhases();
            return phaseList.Select(phase => phase.ToPhaseResponse()).ToList();
        }

        public async Task<List<PhaseSummaryDetailsResponse>> GetSummaryDetailsByBayID(int bayID)
        {
            //var baySummaryDetails = await _dashboardRepository.GetSummaryDetailsByBayID(bayID);
            //return baySummaryDetails.ToPhaseSummaryDetailsResponse();
            List<PhaseSummaryDetails> baySummaryDetails = await _dashboardRepository.GetSummaryDetailsByBayID(bayID);
            return baySummaryDetails.Select(phase => phase.ToPhaseSummaryDetailsResponse()).ToList();

        }
        //public async Task<PhaseSummaryDetailsResponse> PutBayLiveData(PhaseSummaryDetails bayDetails, int bayID)
        //{
        //    var bay = await _dashboardRepository.PutBayLiveData(bayDetails, bayID);
        //    return bay.ToPhaseSummaryDetailsResponse();
        //}


        public async Task<BayResponse> CreateBayByPhaseID(BaySummaryDetails bayDetails, int phaseID)
        {
            var bayDetail = await _dashboardRepository.CreateBayByPhaseID(bayDetails,phaseID);
            return bayDetail.ToBayResponse();
        }

        public async Task<List<BayResponse>> GetBayDetailsByPhaseID(int phaseID)
        {
            var bayDetails = await _dashboardRepository.GetBayDetailsByPhaseID(phaseID);
            return bayDetails.Select(bay=>bay.ToBayResponse()).ToList();
        }

        public async Task<List<NotificationResponse>> GetNotifications()
        {
            List<NotificationDetails> notificationTemparatureList = await _dashboardRepository.GetNotifications();
            return notificationTemparatureList.Select(notificationTemparature => notificationTemparature.ToNotificationResponse()).ToList();
        }

        public async Task<List<NotificationResponse>> GetGlobalSearch(string searchRequest)
        {
            List<NotificationDetails> searchList = await _dashboardRepository.GetGlobalSearch(searchRequest);
            return searchList.Select(searchData => searchData.ToNotificationResponse()).ToList();
        }
    }
}
