using Microsoft.AspNetCore.Http;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Infrastructure.FileServices
{
    public class FileService : IFileService
    {
        public async Task<string> SaveFileAsync(Guid taskId, IFormFile file)
        {
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", taskId.ToString());

            string fileName = file.FileName;
            string filePath = Path.Combine(uploadsFolder, fileName);

            try
            {
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Path.Combine(taskId.ToString(), fileName);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while uploading the file.", ex);
            }
        }
    }
}
