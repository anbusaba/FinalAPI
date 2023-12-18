using SmartMonitoringSystem.Core.Domain.DBEntities;

namespace SmartMonitoringSystem.Core.DTO
{
    public class MemberResponse
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? EmailID { get; set; }


    }
    public static class MemberExtensions
    {
        //Converts from Member object to MemberRepose object
        public static MemberResponse ToMemberResponse(this Member member)
        {
            return new MemberResponse() { UserID = member.UserID, UserName = member.UserName,EmailID=member.EmailID };
        }
    }
}
