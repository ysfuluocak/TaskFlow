using Microsoft.AspNetCore.Http;
using TaskFlow.Application.Common.Results;

namespace TaskFlow.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(Guid taskId, IFormFile file);
    }
}
