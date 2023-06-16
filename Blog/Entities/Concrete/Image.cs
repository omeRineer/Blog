using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Image : BaseEntity<Guid>,IEntity
    {
        public Guid ArticleId { get; set; }
        public string ImageName { get; set; }
        public string Alt { get; set; }

        public Article Article { get; set; }
    }
}
