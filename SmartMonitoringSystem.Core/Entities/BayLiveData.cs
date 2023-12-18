
using System.ComponentModel.DataAnnotations;

namespace SmartMonitoringSystem.Core.Entities
{
    public class BayLiveData
    {
        [Key]
        public int bayLiveId { get; set; }
        public int  bayID { get; set; }
        public DateTime DateTime { get; set; }
        public int Temperature {  get; set; }
        public int Humidity {  get; set; }
    }
}
