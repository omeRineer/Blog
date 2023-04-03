using Business.Abstract;
using Business.Concrete;
using Core.ServiceModules;
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

            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleDal>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            
        }
    }
}
