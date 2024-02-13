using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.File
{
    public class FileInfo
    {
        public string FullPath { get; set; }
        public byte[] ByteContent { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
    }
}
