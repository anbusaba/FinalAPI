using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Core.Domain.DBEntities;
using SmartMonitoringSystem.Core.DTO;
using SmartMonitoringSystem.Core.ServiceContracts;
using SmartMonitoringSystem.Core.Services;
using System.Data.Common;

namespace SmartMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService deviceService;
        private readonly ILogger<DeviceController> _logger;

        public DeviceController(IDeviceService deviceService, ILogger<DeviceController> logger)
        {
            this.deviceService = deviceService;
            _logger = logger;
        }

        [HttpGet("GetAllDevices")]
        public async Task<ActionResult<List<DeviceResponse>>> GetAllDevices()
        {
            try
            {
                var allDevices = await deviceService.GetAllDevices();
                if (allDevices == null)
                {
                    return Problem(detail: "No Such device found", statusCode: 400);
                }
                return allDevices;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in GetAllDevices");
                return new List<DeviceResponse>();
            }
        }

        [HttpPost("AddDevice/{bayID:int}/{deviceID}")]
        public async Task<ActionResult<DeviceDetailsResponse>> CreateDeviceByBayID(CreateDevice addDevice,int bayID, string deviceID)
        {
            try
            {
                var createdDevice = await deviceService.CreateDeviceByBayID(addDevice,bayID,deviceID);
                if (createdDevice == null)
                {
                    return Problem(detail: "No Such device found", statusCode: 400);
                }
                return createdDevice;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in creating a device");
                return new DeviceDetailsResponse();
            }
        }

        [HttpPut("EditDevice/{bayID:int}/{deviceID}")]
        public async Task<ActionResult<DeviceDetailsResponse>> EditDevice(EditDevice editDevice, int bayID, string deviceID)
        {
            try
            {
                var updateDevice = await deviceService.EditDevice(editDevice, bayID, deviceID);
                if (updateDevice == null)
                {
                    return Problem(detail: "No Such device found", statusCode: 400);
                }
                return updateDevice;
            }
            catch (Exception)
            {
                _logger.LogError("Exception occurred in updating a device");
                return new DeviceDetailsResponse();
            }
        }

        [HttpDelete("DeleteDevice/{bayID:int}/{deviceID}")]
        public async Task<IActionResult> DeleteDevice( int bayID, string deviceID)
        {
            try
            {
                var id=await deviceService.GetDevice(bayID,deviceID);
                if (id == null)
                    return NotFound();
                await deviceService.DeleteDevice(bayID,deviceID);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred in deleting a device");
                return StatusCode(500, ex.Message);
            }
        }

    }
}
