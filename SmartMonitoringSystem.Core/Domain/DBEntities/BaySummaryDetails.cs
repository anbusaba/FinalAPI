using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.Domain.DBEntities
{
    public class BaySummaryDetails
    {
        public int BayID { get; set; }
        public int Phase { get; set; }
        public string? BayName { get; set; }
        public string? Floor {  get; set; }
        public int OrganizationID { get; set; }
    }
}
