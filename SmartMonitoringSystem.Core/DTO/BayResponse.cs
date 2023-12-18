using SmartMonitoringSystem.Core.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.DTO
{
    public class BayResponse
    {
        public int BayID { get; set; }
        public int Phase { get; set; }
        public string? BayName { get; set; }
        public string? Floor { get; set; }

        public int OrganizationID { get; set; }
    }

    public static class BayExtensions
    {
        public static BayResponse ToBayResponse(this BaySummaryDetails bay)
        {
            return new BayResponse() 
            { 
                BayID=bay.BayID,
                Phase = bay.Phase, 
                BayName = bay.BayName,
                Floor=bay.Floor , 
                OrganizationID = bay.OrganizationID
            };
        }
    }
}
