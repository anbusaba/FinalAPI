using Dapper;
using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.Domain.RepositoryContracts;
using SmartMonitoringSystem.Core.DTO;
using SmartMonitoringSystem.Infrastructure.DBContext;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SmartMonitoringSystem.Infrastructure.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DapperContext _context;
        public DeviceRepository(DapperContext dapperContext)
        {
            _context = dapperContext;
        }

        public async Task<CreateDevice> CreateDeviceByBayID(CreateDevice addDevice, int bayID, string deviceID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("bayId", bayID, DbType.Int32);
            parameters.Add("deviceId", addDevice.DeviceID, DbType.String);
            parameters.Add("deviceName", addDevice.DeviceName, DbType.String);
            parameters.Add("hardware", addDevice.Hardware, DbType.String);
            parameters.Add("connectionType", addDevice.ConnectionType, DbType.String);
            parameters.Add("authenticationToken", addDevice.AuthToken, DbType.String);
            parameters.Add("status", addDevice.DeviceStatus, DbType.String);
            parameters.Add("description", addDevice.Description, DbType.String);
            parameters.Add("userId", addDevice.UserId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync("sp_CreateDeviceByBayID", parameters);
                var result = new CreateDevice
                {
                    DeviceID = deviceID,
                    BayID = bayID,
                    DeviceName = addDevice.DeviceName,
                    OrganizationId = addDevice.OrganizationId,
                    AuthToken = addDevice.AuthToken,
                    DeviceStatus = addDevice.DeviceStatus,
                    UserId=addDevice.UserId
                };

                return result;
            }
        }

        public async Task DeleteDevice(int bayID, string deviceID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("bayId", bayID, DbType.Int32);
            parameters.Add("deviceId", deviceID, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync("sp_DeleteDevice", parameters);
            }
        }

        public async Task<EditDevice> EditDevice(EditDevice editDevice, int bayID, string deviceID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("bayId", bayID, DbType.Int32);
            parameters.Add("deviceId", deviceID, DbType.String);
            parameters.Add("deviceName", editDevice.DeviceName, DbType.String);
            parameters.Add("hardware", editDevice.Hardware, DbType.String);
            parameters.Add("connectionType", editDevice.ConnectionType, DbType.String);
            parameters.Add("description", editDevice.Description, DbType.String);
            parameters.Add("status", editDevice.DeviceStatus, DbType.String);
            parameters.Add("userId", editDevice.UserId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteAsync("sp_PostEditDevice", parameters);
                var result = new EditDevice
                {
                    DeviceName = editDevice.DeviceName,
                    DeviceStatus = editDevice.DeviceStatus,

                };

                return result;
            }
        }

        public async Task<List<DeviceDetails>> GetAllDevices()
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var results = await connection.QueryAsync<DeviceDetails>(
                    "sp_GetAllDevices",
                    commandType: CommandType.StoredProcedure
                );
                return results?.ToList() ?? new List<DeviceDetails>();
            }
        }

        public async Task<Device> GetDevice(int bayID, string deviceID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("bayId", bayID, DbType.Int32);
            parameters.Add("deviceId", deviceID, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleOrDefaultAsync<int>("sp_GetDeviceDetails", parameters);
                var result = new Device
                {
                    DeviceID = deviceID,
                    BayID = id
                };

                return result;
            }
        }
    }
}
