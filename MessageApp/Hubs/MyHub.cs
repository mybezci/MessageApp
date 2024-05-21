using Microsoft.AspNetCore.SignalR;

namespace MessageApp.Hubs;

public class MyHub : Hub
{
    public async Task SendMessageAsync(string message)
    {
        await Clients.All.SendAsync("ReceiveMessageAsync", message);
    }
}