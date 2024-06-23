using MessageApp.Business;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers;

public class HomeController
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MyBusiness _myBusiness;
        public MessageController(MyBusiness myBusiness)
        {
            _myBusiness = myBusiness;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> SendMessageAsync(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> SendMessageAsyncToUser(string user, string message)
        {
            await _myBusiness.SendMessageAsyncToUser(user, message);
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> SendMessageAsyncToGroup(string group, string message)
        {
            await _myBusiness.SendMessageAsyncToGroup(group, message);
            return Ok();
        }
    }
}