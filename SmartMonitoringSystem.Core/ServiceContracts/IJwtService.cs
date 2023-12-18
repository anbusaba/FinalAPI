using SmartMonitoringSystem.Core.DTO;
using SmartMonitoringSystem.Core.Identity;
using System.Security.Claims;

namespace SmartMonitoringSystem.Core.ServiceContracts
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJWTToken(LoginDto applicationUser);
        ClaimsPrincipal? GetClaimsPrincipalJwtToken(string? token);
        Task<int> LoginUser(LoginDto loginDTO);
        public Task<TokenModel> GetProfileByUserID(int userID);
    }
}
