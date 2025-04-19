using Microsoft.AspNetCore.Http;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(Guid taskId, IFormFile file);
    }
}
