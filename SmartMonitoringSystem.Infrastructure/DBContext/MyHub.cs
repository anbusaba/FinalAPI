using Microsoft.AspNetCore.SignalR;

namespace SmartMonitoringSystem.Infrastructure.DBContext
{
    public class MyHub:Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

    }
}
