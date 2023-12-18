using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.DTO;

namespace SmartMonitoringSystem.Core.Domain.RepositoryContracts
{
    public interface IDashboardRepository
    {
        Task<List<Member>> GetAllMembers();

        Task<List<PhaseSummaryDetails>> GetSummaryDetailsByPhaseID(int phaseID);

        Task<UserProfile> GetProfileByUserID(int userID);

        Task<List<BaySummaryDetails>> GetAllPhases();

        Task<BaySummaryDetails> CreateBayByPhaseID(BaySummaryDetails baySummaryDetails,int phaseID);

        Task<List<BaySummaryDetails>> GetBayDetailsByPhaseID(int phaseID);

        Task<List<PhaseSummaryDetails>> GetSummaryDetailsByBayID(int bayID);


        Task<List<NotificationDetails>> GetNotifications();
        Task<List<NotificationDetails>> GetGlobalSearch(string searchRequest);
    }
}
