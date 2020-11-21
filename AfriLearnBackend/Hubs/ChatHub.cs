using AfriLearnBackend.IRepositories;
using AfriLearnBackend.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AfriLearnBackend.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessagesRepository _messagesRepository;
        public ChatHub(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }
        public async Task  AfriLearnMessage(Message message)
        {
            await Clients.All.SendAsync("AfriLearnMessage", message);
            await _messagesRepository.AddMessage(message);
        }

    }
}
