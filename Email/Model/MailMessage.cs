using Email.Model.Enums;
using Microsoft.AspNetCore.Http;
using MimeKit;
using System.Collections.Generic;

namespace Email.Model
{
    public class MailMessage
    {
        public InternetAddress From { get; set; }
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public MailBodyTypeEnum BodyType { get; set; }
        public IFormFile[]? Files { get; set; }
    }
}
