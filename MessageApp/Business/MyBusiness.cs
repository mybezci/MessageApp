using MessageApp.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace MessageApp.Business;

public class MyBusiness
{
    private readonly IHubContext<MyHub> _hubContext;
    public MyBusiness(IHubContext<MyHub> hubContext)
    {
        _hubContext = hubContext;
    }
    
    public async Task SendMessageAsync(string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
    }
    
    public async Task SendMessageAsyncToUser(string user, string message)
    {
        await _hubContext.Clients.User(user).SendAsync("ReceiveMessage", message);
    }
    
    public async Task SendMessageAsyncToGroup(string group, string message)
    {
        await _hubContext.Clients.Group(group).SendAsync("ReceiveMessage", message);
    }

}