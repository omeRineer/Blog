using Core.Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Category : BaseEntity<int>, IEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<Article> Articles { get; set; }
    }

}
