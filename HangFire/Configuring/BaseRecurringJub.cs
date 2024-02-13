using Hangfire;
using HangFire.Manager.RecurringJobs;
using System.Text;

namespace HangFire.Configuring
{
    public static class BaseRecurringJub
    {
        public static void Run()
        {
            RecurringJob.RemoveIfExists(nameof(WeeklyBlogEmailJob));
            RecurringJob.AddOrUpdate<WeeklyBlogEmailJob>(nameof(WeeklyBlogEmailJob), job => job.Run(), Cron.Minutely);
        }
    }
}
