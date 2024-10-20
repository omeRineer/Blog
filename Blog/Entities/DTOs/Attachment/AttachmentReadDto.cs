using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Attachment
{
    public class AttachmentReadDto
    {
        public long Id { get; set; }
        public Guid ArticleId { get; set; }
        public string FileName { get; set; }
        public string Meta { get; set; }
        public string? Base64 { get; set; }
    }
}
