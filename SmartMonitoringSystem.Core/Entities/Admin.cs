
using System.ComponentModel.DataAnnotations;

namespace SmartMonitoringSystem.Core.Entities
{
    public class Admin
    {
        [Key]
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? EmailID { get; set; }
        public string? Password { get; set; }
    }
}
