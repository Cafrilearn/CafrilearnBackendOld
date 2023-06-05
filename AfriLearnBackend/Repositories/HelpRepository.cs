using AfriLearnBackend.IRepositories;
using AfriLearnBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AfriLearnBackend.Repositories
{
    public class HelpRepository : IHelpRepository
    {
        private readonly AfriLearnDbContext _afriLearnDbContext;
        
        public HelpRepository(AfriLearnDbContext afriLearnDbContext)
        {
            _afriLearnDbContext = afriLearnDbContext;
        } 

        public Task AddHelpRequest(Help help)
        {
            _afriLearnDbContext.Add(help);

            return _afriLearnDbContext.SaveChangesAsync();
        }

        public Task DeleteHelpRequest(int id)
        {
            _afriLearnDbContext.Remove(_afriLearnDbContext.HelpRequests.Find(id));

            return _afriLearnDbContext.SaveChangesAsync();
        }

        public Help GetHelpRequestById(int id)
        {
            return _afriLearnDbContext.HelpRequests.Find(id);
        }

        public IEnumerable<Help> GetHelpRequests()
        {
            return _afriLearnDbContext.HelpRequests;
        }

        public Task UpdateHelpRequest(Help help)
        {
            _afriLearnDbContext.Update(help);

            return _afriLearnDbContext.SaveChangesAsync();
        }
    }
}
