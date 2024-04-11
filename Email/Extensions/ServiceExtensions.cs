using Email.Model.Options;
using Email.Service;
using Email.Service.MailService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddEmailService(this IServiceCollection services, Action<EmailOptions> options)
        {
            services.Configure(options);
            services.AddSingleton<IEmailService, MimeKitMailService>();
        }
    }
}
