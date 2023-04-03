using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Article
{
    public class ArticleCreateDto
    {
        public string Header { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
    }
}
