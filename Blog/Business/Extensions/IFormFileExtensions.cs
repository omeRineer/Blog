using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class IFormFileExtensions
    {
        public static string GetExtension(this IFormFile file)
        {
            return Path.GetExtension(file.FileName);
        }
    }
}
