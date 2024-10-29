using Entities.DTOs.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Comment
{
    public class CommentReadDto
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool? IsOnline { get; set; }
        public DateTime CreateDate { get; set; }


        public CommentRead_Article Article { get; set; }
    }

    public class CommentRead_Article
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
