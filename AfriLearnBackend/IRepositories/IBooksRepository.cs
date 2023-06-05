using CafrilearnBackend.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafrilearnBackend.IRepositories;

public interface IBooksRepository
{
    Task GetBook(string bookType, string bookFormat);
    Task<byte[]> GetBlobAsync(Book book);
    Task<List<string>> GetFilesListAsync(string containerType);
    Task<List<string>> GetAllBookNames();
    CloudBlobContainer GetBlobContainer(string containerType);
}

