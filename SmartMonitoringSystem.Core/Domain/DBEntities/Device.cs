using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.Domain.DBEntities
{
    public class Device
    {
        public string? DeviceID { get; set; }
        public string? DeviceName { get; set; }
        public string? DeviceOwner { get; set; }
        public string? OrganizationId { get; set; }
        public string? AuthToken { get; set; }
        public string? DeviceStatus { get; set; }
        public int BayID { get; set; }
    }
}
