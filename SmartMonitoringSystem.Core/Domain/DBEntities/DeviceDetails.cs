using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.Domain.DBEntities
{
    public class DeviceDetails
    {
        public string? DeviceName { get; set; }
        public string? AuthenticationToken { get; set; }
        public string? Status { get; set; }
        public string? UserName { get; set; }
        public string? OrganisationName { get; set; }
    }
}
