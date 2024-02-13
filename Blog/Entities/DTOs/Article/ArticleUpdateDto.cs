using System;

namespace Entities.DTOs.Article
{
    public class ArticleUpdateDto
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }

    
}
