using Microsoft.AspNetCore.Http;

namespace TaskFlow.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(Guid taskId, IFormFile file);
    }
}
