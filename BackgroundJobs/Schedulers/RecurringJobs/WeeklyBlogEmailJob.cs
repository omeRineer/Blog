using BackgroundJobs.Schedulers.Base;
using Configuration;
using Core.Utilities.ServiceTools;
using DataAccess.Abstract;
using Email.Model;
using Email.Model.Enums;
using Email.Service;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateEngine.Service;
using TemplateEngine.Templates;

namespace BackgroundJobs.Schedulers.RecurringJobs
{
    public interface IWeeklyBlogEmailJob : IRecurringJob
    {
    }
    public class WeeklyBlogEmailJob : IWeeklyBlogEmailJob
    {
        readonly ISubscriberDal _subscriberDal;
        readonly IEmailService _emailService;
        readonly IArticleDal _articleDal;

        public WeeklyBlogEmailJob()
        {
            _subscriberDal = StaticServiceProvider.GetService<ISubscriberDal>();
            _emailService = StaticServiceProvider.GetService<IEmailService>();
            _articleDal = StaticServiceProvider.GetService<IArticleDal>();
        }

        public async Task Run()
        {
            var subscribers = _subscriberDal.GetAll(isGetPaging: false);

            //var toList = subscribers.Select(s => new MailboxAddress(CoreConfiguration.EmailOptions.From, s.Email)).ToList();
            var contents = _articleDal.GetAll(filter: f=>f.Status == true,
                                              includes:i=>i.Include(x=>x.Category),
                                              orderBy: o=> o.OrderByDescending(x=>x.CreateDate));

            foreach (var item in subscribers)
            {
                await _emailService.SendAsync(new MailMessage
                {
                    Subject = "Blog Yazılarıma Göz At",
                    Body = await RazorEngine.CompileRenderAsync(Template.Email.WelcomeTemplate, contents),
                    BodyType = MailBodyTypeEnum.HTML,
                    From = new MailboxAddress(CoreConfiguration.EmailOptions.From, CoreConfiguration.EmailOptions.UserName),
                    To = new List<MailboxAddress>
                    {
                        new MailboxAddress(CoreConfiguration.EmailOptions.From, item.Email)
                    }
                });
            }
            
        }
    }
}
