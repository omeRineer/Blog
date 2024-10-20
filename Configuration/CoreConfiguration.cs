using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using IO = System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.DTO.Options;
using Core.Utilities.Identities.Jwt;

namespace Configuration
{
    public static class CoreConfiguration
    {
        readonly static IConfigurationRoot Configuration;
        static CoreConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();
        }

        public static string ConnectionString { get => Configuration.GetConnectionString("BlogDbConnectionString"); }
        public static EmailOptions EmailOptions { get => Configuration.GetSection("EmailOptions").Get<EmailOptions>(); }
        public static TokenOptions TokenOptions { get => Configuration.GetSection("TokenOptions").Get<TokenOptions>(); }

    }
}
