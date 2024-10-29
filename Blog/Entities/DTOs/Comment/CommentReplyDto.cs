using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Comment
{
    public class CommentReplyDto
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsOnline { get; set; }
    }
}
