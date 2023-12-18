using SmartMonitoringSystem.Core.Domain.DBEntities;

namespace SmartMonitoringSystem.Core.DTO
{
    public class UserProfileResponse
    {
        public string? UserName { get; set; }
        public int UserID { get; set; }
        public string? Email { get; set; }
    }
    public static class UserProfileExtension
    {
        //Converts from UserProfile object to UserProfileResponse object
        public static UserProfileResponse ToUserProfile(this UserProfile profile)
        {
            return new UserProfileResponse() { UserName = profile.UserName, Email = profile.EmailID,UserID=profile.UserID};
        }

        public static TokenModel ToTokenModelResponse(this UserProfile profile)
        {
            return new TokenModel() {  Email = profile.EmailID, ID = profile.UserID};
        }
    }
}
