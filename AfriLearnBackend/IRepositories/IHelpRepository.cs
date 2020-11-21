using AfriLearnBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AfriLearnBackend.IRepositories
{
    public interface IHelpRepository
    {
        Task AddHelpRequest(Help help);
        IEnumerable<Help> GetHelpRequests();
        Help GetHelpRequestById(int id);
        Task DeleteHelpRequest(int id);
        Task UpdateHelpRequest(Help help);
    }
}
