using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.DTO;

namespace SmartMonitoringSystem.Core.Domain.RepositoryContracts
{
    public interface ILoginRepository
    {
        Task<int> LoginUser(LoginDto loginDTO);
        public Task<UserProfile> GetProfileByUserID(int userID);
    }
}
