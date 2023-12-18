using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.DTO;

namespace SmartMonitoringSystem.Core.ServiceContracts
{
    public interface IDashboardService
    {
       
        Task<List<MemberResponse>> GetAllMembers();

        Task<List<PhaseSummaryDetailsResponse>> GetSummaryDetailsByPhaseID(int phaseID);

        Task<UserProfileResponse> GetProfileByUserID(int userID);

        Task<List<PhaseResponse>> GetAllPhases();
        Task<BayResponse> CreateBayByPhaseID(BaySummaryDetails baySummaryDetails,int phaseID);

        Task<List<BayResponse>> GetBayDetailsByPhaseID(int phaseID);

        Task<List<PhaseSummaryDetailsResponse>> GetSummaryDetailsByBayID(int bayID);
        //Task<PhaseSummaryDetails> PutBayLiveData(PhaseSummaryDetails bayDetails, int bayID);
        //Task<PhaseSummaryDetailsResponse> PutBayLiveData(PhaseSummaryDetails bay, int bayID);
        
        Task<List<NotificationResponse>> GetNotifications();
        Task<List<NotificationResponse>> GetGlobalSearch(string searchRequest);
    }
}
