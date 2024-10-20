using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MetaTicket
{
    public class MetaTicketReadDto
    {
        public int Id { get; set; }
        public Guid ArticleId { get; set; }
        public string Title { get; set; }
        public string KeyWords { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
