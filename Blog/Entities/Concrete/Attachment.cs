using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Attachment : BaseEntity<int>, IEntity
    {
        public Guid ArticleId { get; set; }
        public string FileName { get; set; }
        public string? Meta { get; set; }

        public Article Article { get; set; }
    }
}
