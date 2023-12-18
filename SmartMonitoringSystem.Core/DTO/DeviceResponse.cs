using SmartMonitoringSystem.Core.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.DTO
{
    public class DeviceResponse
    {
        public string? DeviceName { get; set; }       
        public string? AuthenticationToken { get; set; }        
        public string? Status { get; set; }
        public string? UserName { get; set; }
        public string? OrganisationName { get; set; }

    }
    public static class DeviceResponseExtension
    {
        //Converts from DeviceResponse object to DeviceResponse object
        public static DeviceResponse ToDeviceResponse(this DeviceDetails deviceDetails)
        {
            return new DeviceResponse() { DeviceName = deviceDetails.DeviceName, AuthenticationToken = deviceDetails.AuthenticationToken, Status = deviceDetails.Status,UserName=deviceDetails.UserName,OrganisationName=deviceDetails.OrganisationName };
        }
    }
}
