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
        public int ReaderCount { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
