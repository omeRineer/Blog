using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MetaTicket : BaseEntity<int>, IEntity
    {
        public string Title { get; set; }
        public string KeyWords { get; set; }
        public string Description { get; set; }

        public Article Article { get; set; }
    }
}
