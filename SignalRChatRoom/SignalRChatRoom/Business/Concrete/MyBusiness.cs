using Microsoft.AspNetCore.SignalR;
using SignalRChatRoom.Business.Interface;
using SignalRChatRoom.Hubs;

namespace SignalRChatRoom.Business.Concrete
{
    public class MyBusiness : IMyBusiness
    {
        private readonly IHubContext<MyHub> _hubContext;
        public MyBusiness(IHubContext<MyHub> hubContext)
        {
           _hubContext = hubContext;
        }
        public async Task SendMessageAsync(string message, string userName)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message, userName);
        }
    }

}
