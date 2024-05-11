using Microsoft.AspNetCore.Http;

namespace TechBlog.Service.Services.Abstractions.Storage
{
    public interface IStorage
    {
        bool HasFile(string pathOrContainerName, string fileName);
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);
        List<string> GetFiles(string pathOrContainerName);
        // note: For the local storage service, it is necessary to pay attention to the async operation of the DeleteAsync method!
        Task DeleteAsync(string pathOrContainerName, string fileName);
    }
}
