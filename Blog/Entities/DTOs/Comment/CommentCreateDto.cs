using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Comment
{
    public class CommentCreateDto
    {
        public Guid ArticleId { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
