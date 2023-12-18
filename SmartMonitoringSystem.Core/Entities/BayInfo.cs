using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartMonitoringSystem.Core.Entities
{
    public class BayInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BayID { get; set; }
        public string? BayName { get; set; }
        public int Phase { get; set; }
        public int OrganisationID { get; set; }
        public string? Floor {  get; set; }
    }
}
