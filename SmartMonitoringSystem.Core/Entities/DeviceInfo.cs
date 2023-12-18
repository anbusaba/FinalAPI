using System.ComponentModel.DataAnnotations;

namespace SmartMonitoringSystem.Core.Entities
{
    public class DeviceInfo
    {
        [Key]
        public int DeviceInfoId {  get; set; }
        public int BayID { get; set; }
        public string? DeviceID {  get; set; }
        public string? DeviceName { get; set; }
        public string? ConnectionType { get; set;}
        public string? AuthenticationToken { get; set;}
        public string? Hardware { get; set;}
        public string? Description {  get; set;}
        public string? Status { get; set;}
        public int UserId { get; set; }
    }
    }

