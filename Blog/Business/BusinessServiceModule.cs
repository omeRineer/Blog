using Business.Abstract;
using Business.Concrete;
using Business.Mappers;
using Core.ServiceModules;
using Core.Utilities.ServiceTools;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessServiceModule : IServiceModule
    {
        private readonly IConfiguration Configuration;

        public BusinessServiceModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IMetaTicketService, MetaTicketManager>();
            services.AddScoped<IMetaTicketDal, EfMetaTicketDal>();
            services.AddScoped<IAuthService, AuthManager>();

            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BlogDbConnectionString"));
            });

        }
    }
}
