using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRChatRoom.Business.Interface;

namespace SignalRChatRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private readonly IMyBusiness _myBusiness;
        public SenderController(IMyBusiness myBusiness)
        {
            _myBusiness = myBusiness;
        }

        [HttpGet("{message}/{userName}")]
        public async Task<IActionResult> SendMyMessage(string message, string userName)
        {
            await _myBusiness.SendMessageAsync(message, userName);
            return Ok();
        }
    }
}
