using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using SmartMonitoringSystem.Infrastructure.DBContext;

namespace SmartMonitoringSystem.Infrastructure.Repository
{
    public class SchedulerServiceRepository : IHostedService, IDisposable
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHubContext<MyHub> _hubContext;
        private Timer _timer;
        public SchedulerServiceRepository(IHttpClientFactory httpClientFactory,IHubContext<MyHub> hubContext)
        {
            _httpClientFactory = httpClientFactory;
            _hubContext = hubContext;
        }
    
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(TriggerNotification, null, TimeSpan.Zero, TimeSpan.FromMinutes(15));
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }

        private async void TriggerNotification(object? state)
        {
            // Invoking API call 
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7191/api/Dashboard/GetNotifications");

            //Notify connected clients using SignalR
            if (response.IsSuccessStatusCode)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", "API call is triggered");
            }
        }


    }
    }


   
