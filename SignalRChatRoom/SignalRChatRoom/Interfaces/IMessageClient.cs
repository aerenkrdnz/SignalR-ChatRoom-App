using SignalRChatRoom.Hubs;

namespace SignalRChatRoom.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<ClientData> clients);
        Task UserJoined(ClientData data);
        Task UserLeaved(ClientData data);
        Task ReceiveMessage(string message, string userName, string connectionId);
    }
}
