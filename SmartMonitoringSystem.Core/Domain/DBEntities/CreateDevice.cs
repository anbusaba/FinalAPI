using SmartMonitoringSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.Domain.DBEntities
{
    public class CreateDevice
    {
        public string? DeviceID { get; set; }
        public string? DeviceName { get; set; }
        public string? DeviceOwner { get; set; }
        public string? OrganizationId { get; set; }
        public string? AuthToken { get; set; }
        public string? DeviceStatus { get; set; }
        public string? Hardware { get; set; }
        public string? ConnectionType { get; set; }    
        public string? Description { get; set; }
        public int BayID { get; set; }
        public int UserId { get; set; }
    }
    public static class DeviceExtension
    {
        public static DeviceDetailsResponse ToCreateDeviceResponse(this CreateDevice device)
        {
            return new DeviceDetailsResponse()
            {
                DeviceID = device.DeviceID,
                DeviceName = device.DeviceName,
                DeviceOwner = device.DeviceOwner,
                OrganizationId = device.OrganizationId,
                AuthToken = device.AuthToken,
                DeviceStatus = device.DeviceStatus,
                BayID = device.BayID,
                UserId=device.UserId
                
            };
        }
    }
}
