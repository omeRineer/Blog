using Entities.DTOs.Attachment;
using Entities.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Article
{
    public class ArticleReadDto
    {
        public Guid Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public int ReaderCount { get; set; }
        public DateTime CreateDate { get; set; }
        public List<AttachmentReadDto>? Attachments { get; set; }
        public List<CommentReadDto>? Comments { get; set; }
    }
}
