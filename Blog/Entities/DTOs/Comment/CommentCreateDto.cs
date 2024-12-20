﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Comment
{
    public class CommentCreateDto
    {
        public string ArticleId { get; set; }
        public string? ParentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
