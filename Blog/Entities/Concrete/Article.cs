using Core.Entities.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Article : BaseEntity<Guid>, IEntity
    {
        public int CategoryId { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int ReaderCount { get; set; }
        public bool Status { get; set; }

        public Category Category { get; set; }
        public MetaTicket MetaTicket { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

}
