using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Services.File
{
    public class FileService:IFileService
    {
        private readonly IHostingEnvironment _environment;

        public FileService(IHostingEnvironment environment)
        {
            _environment = environment;
        }
       

        public async Task<ServiceResult<string>> AddFile(IFormFile file, string path)
        {
            var wwwrootPath = _environment.ContentRootPath + "\\wwwroot";
            var fileName = $"{Guid.NewGuid()}.jpg";
            var pname = path +"\\"+ fileName;
            var saveToPath = Path.Combine(wwwrootPath, path);
            if (!Directory.Exists(saveToPath))
            {
                Directory.CreateDirectory(saveToPath);
            }
            var fileAddress = Path.Combine(wwwrootPath, path, fileName);

            using var stream = new FileStream(fileAddress, FileMode.Create);
            await file.CopyToAsync(stream);

            return fileName;
        }


    }
}
