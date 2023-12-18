using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.Domain.RepositoryContracts;
using SmartMonitoringSystem.Core.DTO;
using SmartMonitoringSystem.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoringSystem.Core.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly Random _random = new Random();

        public DeviceService(IDeviceRepository dashboardRepository)
        {
            _deviceRepository = dashboardRepository;
        }

        public async Task<DeviceDetailsResponse> CreateDeviceByBayID(CreateDevice createDevice, int bayID,string deviceID)
        {
            createDevice.AuthToken = GenerateAuthToken();
            var addDevice = await _deviceRepository.CreateDeviceByBayID(createDevice,bayID,deviceID);
            return addDevice.ToCreateDeviceResponse();
        }

        public async Task DeleteDevice(int bayID, string deviceID)
        {
            await _deviceRepository.DeleteDevice(bayID, deviceID);
        }

        public async Task<DeviceDetailsResponse> EditDevice(EditDevice editDevice, int bayID, string deviceID)
        {
            var device = await _deviceRepository.EditDevice(editDevice, bayID, deviceID);
            return device.ToEditDeviceResponse();
        }

        public async Task<List<DeviceResponse>> GetAllDevices()
        {
            List<DeviceDetails> deviceDetails = await _deviceRepository.GetAllDevices();
            return deviceDetails.Select(device => device.ToDeviceResponse()).ToList();
        }
        private string GenerateAuthToken()
        {
            var passwordBuilder = new StringBuilder();

            // 4-Letters lower case
            passwordBuilder.Append(RandomString(4, true));

            // 4-Digits between 1000 and 9999
            passwordBuilder.Append(RandomNumber(1000, 9999));

            // 2-Letters upper case
            passwordBuilder.Append(RandomString(2));
            return passwordBuilder.ToString();
        }
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Generates a random string with a given size.
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.

            // char is a single Unicode character
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public async Task<Device> GetDevice(int bayID, string deviceID)
        {
            return await _deviceRepository.GetDevice(bayID, deviceID);
        }

    }
}
