using Microsoft.AspNetCore.SignalR;
using SignalRChatRoom.Interfaces;

namespace SignalRChatRoom.Hubs
{
    public class ClientData
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
    }
    public class MyHub : Hub<IMessageClient>
    {
        static List<ClientData> clients = new List<ClientData>();
        public async Task SendMessageAsync(string message, string userName)
        {
            await Clients.All.ReceiveMessage(message, userName, Context.ConnectionId);
        }
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var userName = httpContext.Request.Query["UserName"];

            var data = new ClientData { ConnectionId = Context.ConnectionId, UserName = userName };
            clients.Add(data);

            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(data);
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var httpContext = Context.GetHttpContext();
            var userName = httpContext.Request.Query["UserName"];

            var data = new ClientData { ConnectionId = Context.ConnectionId, UserName = userName };
            var deletedClient = clients.FirstOrDefault(x => x.ConnectionId == data.ConnectionId);
            clients.Remove(deletedClient);

            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(data);
        }
    }
}
