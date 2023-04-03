using Core.Extensions;
using Core.Utilities.Helpers;
using Core.Utilities.Identities.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceModules
{
    public class MeArchitectureServiceModule : IServiceModule
    {
        private readonly IConfiguration Configuration;
        private readonly TokenOptions TokenOptions;
        public MeArchitectureServiceModule(IConfiguration configuration)
        {
            Configuration = configuration;
            TokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

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

                        ValidIssuer = TokenOptions.Issuer,
                        ValidAudience = TokenOptions.Audience,
                        IssuerSigningKey = SecurityKeyHelper.GetSecurityKey(TokenOptions.SecurityKey)

                    };
                });

            services.AddTokenService(options =>
            {
                options.Audience = TokenOptions.Audience;
                options.Issuer = TokenOptions.Issuer;
                options.ExpirationTime = TokenOptions.ExpirationTime;
                options.SecurityKey = TokenOptions.SecurityKey;
            });
        }
    }
}
