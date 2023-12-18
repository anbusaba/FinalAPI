using System.ComponentModel.DataAnnotations;

namespace SmartMonitoringSystem.Core.Domain.DBEntities
{
    public class Member
    {
        [Key]
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? EmailID { get; set;}

    }

}
