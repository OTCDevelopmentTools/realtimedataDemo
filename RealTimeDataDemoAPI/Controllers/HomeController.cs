using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeDataDemoAPI.Hubs;
using RealTimeDataDemoAPI.Models;

namespace RealTimeDataDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public HomeController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("PushEmployee")]
        public IActionResult PushEmployee(int Id, string name, string address)
        {
            Employee employee = new Employee();
            employee.Id = Id;
            employee.Name = name;
            employee.Address = address;

            _hubContext.Clients.All.SendAsync("ReceiveEmployee", employee);
            return Ok("Done");
        }

        [HttpGet]
        [Route("PushMessage")]
        public IActionResult PushMessage(string message)
        {
            _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
            return Ok("Done");
        }
    }
}
