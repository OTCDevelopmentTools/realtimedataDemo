using Microsoft.AspNetCore.SignalR;
using RealTimeDataDemoAPI.Models;

namespace RealTimeDataDemoAPI.Hubs
{
    public class NotificationHub : Hub
    {
        public NotificationHub()
        {

        }

        public void BroadcastEmployee(Employee Emp)
        {
            Clients.All.SendAsync("ReceiveEmployee", Emp);
        }

        public void BroadcastMessage(string message)
        {
            Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
