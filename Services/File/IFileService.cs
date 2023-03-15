using Microsoft.AspNetCore.Http;

namespace Services.File
{
    public interface IFileService
    {
        Task<ServiceResult<string>> AddFile(IFormFile file, string path);
    }
}
