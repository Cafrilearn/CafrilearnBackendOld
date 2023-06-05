using CafrilearnBackend.IRepositories;
using CafrilearnBackend.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CafrilearnBackend.Hubs;

public class ChatHub : Hub
{
    private readonly IMessagesRepository _messagesRepository;

    public ChatHub(IMessagesRepository messagesRepository)
    {
        _messagesRepository = messagesRepository;
    }

    public async Task AfriLearnMessage(Message message)
    {
        await Clients.All.SendAsync("CafrilearnMessage", message);
        await _messagesRepository.AddMessage(message);
    }
}

