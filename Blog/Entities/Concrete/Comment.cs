using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : BaseEntity<Guid>, IEntity
    {
        public Guid ArticleId { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool? IsOnline { get; set; }


        public Article Article { get; set; }
        public Comment ParentComment { get; set; }
    }
}
