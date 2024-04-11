using Configuration;
using Core.Extensions;
using Core.ServiceModules;
using Core.Utilities.Helpers;
using Core.Utilities.Identities.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using Email.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MeArchitectureServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,

                        ValidIssuer = CoreConfiguration.TokenOptions.Issuer,
                        ValidAudience = CoreConfiguration.TokenOptions.Audience,
                        IssuerSigningKey = SecurityKeyHelper.GetSecurityKey(CoreConfiguration.TokenOptions.SecurityKey)

                    };
                });

            services.AddTokenService(options =>
            {
                options.Audience = CoreConfiguration.TokenOptions.Audience;
                options.Issuer = CoreConfiguration.TokenOptions.Issuer;
                options.ExpirationTime = CoreConfiguration.TokenOptions.ExpirationTime;
                options.SecurityKey = CoreConfiguration.TokenOptions.SecurityKey;
            });

            services.AddEmailService(options =>
            {
                options.Host = CoreConfiguration.EmailOptions.Host;
                options.Port = CoreConfiguration.EmailOptions.Port;
                options.UseSSL = CoreConfiguration.EmailOptions.UseSSL;
                options.UserName = CoreConfiguration.EmailOptions.UserName;
                options.Password = CoreConfiguration.EmailOptions.Password;
            });
        }
    }
}
