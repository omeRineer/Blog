using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Mail : BaseEntity<int>, IEntity
    {
        public string Email { get; set; }
    }
}
