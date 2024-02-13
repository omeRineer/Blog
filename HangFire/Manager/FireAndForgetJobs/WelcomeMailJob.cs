using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HangFire.Manager.FireAndForgetJobs
{
    public class WelcomeMailJob
    {
        private readonly Context context;

        public WelcomeMailJob(Context context)
        {
            this.context = context;
        }

        public async Task Run()
        {
            var emails = context.Set<Article>();

            await emails.ForEachAsync(x =>
            {
                Console.WriteLine(x.Header);
            });
        }
    }
}
