using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.File
{
    public class FileOptionsParameter
    {
        public string Directory { get; set; }
        public string? NameTemplate { get; set; }
    }
}
