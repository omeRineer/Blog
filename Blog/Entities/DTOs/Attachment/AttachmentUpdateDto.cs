using System;

namespace Entities.DTOs.Attachment
{
    public class AttachmentUpdateDto
    {
        public int Id { get; set; }
        public Guid ArticleId { get; set; }
        public string FileName { get; set; }
        public string Base64 { get; set; }
        public string MediaType { get; set; }
    }
}
