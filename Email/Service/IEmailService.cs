using Core.Utilities.ResultTool;
using Email.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Service
{
    public interface IEmailService
    {
        Task<IResult> SendAsync(MailMessage message);
    }
}
