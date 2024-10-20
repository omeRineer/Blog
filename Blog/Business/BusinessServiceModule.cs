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
using Configuration;

namespace Business
{
    public class BusinessServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddAutoMapper(typeof(BackgroundJobProfile));

            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleDal>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<IAttachmentDal, EfAttachmentDal>();

            services.AddScoped<IMetaTicketService, MetaTicketManager>();
            services.AddScoped<IMetaTicketDal, EfMetaTicketDal>();

            services.AddScoped<IAuthService, AuthManager>();

            services.AddScoped<ISubscriberDal, EfSubscriberDal>();
            services.AddScoped<ISubscriberService, SubscriberService>();

            services.AddScoped<ICommentDal, EfCommmentDal>();
            services.AddScoped<ICommentService, CommentManager>();


            services.AddScoped<IBackgroundJobDal, EfBackgroundJobDal>();
            services.AddScoped<IBackgroundJobService, BackgroundJobService>();

            

            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(CoreConfiguration.ConnectionString);
            });

        }
    }
}
