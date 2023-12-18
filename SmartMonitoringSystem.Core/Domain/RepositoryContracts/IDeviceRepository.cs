using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.Domain.RepositoryContracts
{
    public interface IDeviceRepository
    {
        Task<List<DeviceDetails>> GetAllDevices();
        Task<CreateDevice> CreateDeviceByBayID(CreateDevice addDevice, int bayID, string deviceID);

        Task<EditDevice> EditDevice(EditDevice editDevice, int bayID, string deviceID);
        Task DeleteDevice(int bayID, string deviceID);

        Task<Device> GetDevice(int bayID, string deviceID);
    }
}
