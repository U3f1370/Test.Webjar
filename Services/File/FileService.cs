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
        private readonly ResourceManager _resourceManager;
        private readonly IConfiguration _configuration;

        public FileService(IHostingEnvironment environment, ResourceManager resourceManager, IConfiguration configuration)
        {
            _environment = environment;
            _resourceManager = resourceManager;
            _configuration = configuration;
        }
        public async Task<ServiceResult<string>> AddFile(Stream file)
        {
            var filename = $"{Guid.NewGuid()}.jpg";
            var midPath = Path.Combine(_configuration["SiteSettings:PathFile"], filename);
            var relatedPath = Path.Combine(_environment.ContentRootPath, "wwwroot", _configuration["SiteSettings:PathFile"]);

            if (!Directory.Exists(relatedPath))
                Directory.CreateDirectory(relatedPath);

            var fullPath = Path.Combine(_environment.ContentRootPath, "wwwroot", midPath);

            using (var outputFileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(outputFileStream);
            }

            return midPath;

        }


    }
}
