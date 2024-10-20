using System;

namespace Entities.DTOs.MetaTicket
{
    public class MetaTicketCreateDto
    {
        public Guid ArticleId { get; set; }
        public string Title { get; set; }
        public string KeyWords { get; set; }
        public string Description { get; set; }
    }
}
