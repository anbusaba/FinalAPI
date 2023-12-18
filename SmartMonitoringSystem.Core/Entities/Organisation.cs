using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartMonitoringSystem.Core.Entities
{
    public class Organisation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganisationId { get; set; }
        public string? OrganisationName { get; set; } 
        public string? Location { get; set; }

    }
}
