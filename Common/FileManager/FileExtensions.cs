using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.FileManager
{
    public static class FileExtensions
    {
        public sealed class AllowedExtensionsVAttribute : ValidationAttribute
        {
            public string[] Extensions { get; set; } = new string[5] { ".png", ".jpg", ".jpeg", ".gif", ".mp4" };
            public AllowedExtensionsVAttribute()
            {

            }

            public override bool IsValid(object value)
            {
                if (value == null)
                    return true;

                var file = value as IFormFile;
                if (file == null)
                    throw new Exception($"{nameof(value)} can not convert to IFormFile");

                var extention = System.IO.Path.GetExtension(file.FileName);
                if (string.IsNullOrEmpty(extention))
                    return false;
                var exist = Extensions.Any(x => x.Equals(extention, StringComparison.OrdinalIgnoreCase));
                return exist;
            }
        }
    }
}
