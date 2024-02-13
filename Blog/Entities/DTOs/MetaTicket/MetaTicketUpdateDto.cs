using System;

namespace Entities.DTOs.MetaTicket
{
    public class MetaTicketUpdateDto
    {
        public int Id { get; set; }
        public Guid ArticleId { get; set; }
        public string Title { get; set; }
        public string KeyWords { get; set; }
        public string Description { get; set; }
    }
}
