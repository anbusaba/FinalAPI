using SmartMonitoringSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.Domain.DBEntities
{
    public class EditDevice
    {
        public string? DeviceStatus { get; set; }
        public string? Hardware { get; set; }
        public string? ConnectionType { get; set; }
        public string? Description { get; set; }
        public string? DeviceName { get; set; }
        public int UserId { get; set; }
    }
    public static class EditDeviceExtension
    {
        public static DeviceDetailsResponse ToEditDeviceResponse(this EditDevice device)
        {
            return new DeviceDetailsResponse()
            {
                DeviceName = device.DeviceName,
                DeviceStatus = device.DeviceStatus,
            };
        }
    }
}
