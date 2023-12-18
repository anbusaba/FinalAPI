using SmartMonitoringSystem.Core.Domain.DBEntities;

namespace SmartMonitoringSystem.Core.DTO
{
    public class NotificationResponse
    {
        public string? BayName { get; set; }      
        public DateTime DateTime { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }


    }
    public static class NotificationExtension
    {
        //Converts from NotificationDetails object to ToNotificationResponse object
        public static NotificationResponse ToNotificationResponse(this NotificationDetails notificationDetails)
        {
            return new NotificationResponse() { BayName=notificationDetails.BayName,Temperature = notificationDetails.Temperature, Humidity = notificationDetails.Humidity, DateTime = notificationDetails.DateTime };
        }
    }
}
