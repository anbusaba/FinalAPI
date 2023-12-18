using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.ServiceContracts
{
    public interface IDeviceService
    {
        Task<List<DeviceResponse>> GetAllDevices();
        Task<DeviceDetailsResponse> CreateDeviceByBayID(CreateDevice createDevice,int bayID,string deviceID);

        Task<DeviceDetailsResponse> EditDevice(EditDevice editDevice,int bayID,string deviceID);
        Task DeleteDevice(int bayID,string deviceID);
        Task<Device> GetDevice(int bayID, string deviceID);
    }
}
