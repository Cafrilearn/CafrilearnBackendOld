using AfriLearnBackend.IRepositories;
using AfriLearnBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfriLearnBackend.Repositories
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly AfriLearnDbContext _dbContext;
        public MessagesRepository(AfriLearnDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Message> AddMessage(Message message)
        {
            _dbContext.Messages.Add(message);
            await _dbContext.SaveChangesAsync();
            return message;
        }

        public async Task DeleteMessage(int id)
        {
            _dbContext.Messages.Remove(_dbContext.Messages.Find(id));
            await _dbContext.SaveChangesAsync();            
        }

        public Message GetMessageById(int id)
        {
            return _dbContext.Messages.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Message> GetMessages()
        {
            return _dbContext.Messages;
        }

        public async Task UpdateMessage(Message message)
        {
            _dbContext.Update(message);
            await _dbContext.SaveChangesAsync();
        }
    }
}
