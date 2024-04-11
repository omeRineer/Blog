using BackgroundJobs.Models;
using BackgroundJobs.Schedulers.Base;
using Core.Utilities.ServiceTools;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HangFire.Configuring
{
    public interface IGeneralSchedulerService
    {
        void Run();
    }
    public class GeneralSchedulerService : IGeneralSchedulerService
    {
        readonly IBackgroundJobDal _backgroundJobDal;
        readonly IMemoryCache _memoryCache;

        public GeneralSchedulerService(IBackgroundJobDal backgroundJobDal, IMemoryCache memoryCache)
        {
            _backgroundJobDal = backgroundJobDal;
            _memoryCache = memoryCache;
        }

        public void Run()
        {
            var recurringJobs = _backgroundJobDal.GetAll(isGetPaging: false);

            ClearAllJobs(recurringJobs);

            var selectedJobs = GetRecurringJobsAsync(recurringJobs);

            foreach (var selectedJob in selectedJobs)
            {
                var jobEntity = recurringJobs.SingleOrDefault(f => f.JobName == selectedJob.JobName && f.IsActive);

                if (jobEntity != null)
                    RecurringJob.AddOrUpdate(jobEntity.Id.ToString(), selectedJob.Action, jobEntity.Cron);
            }
        }

        private List<JobModel> GetRecurringJobsAsync(List<Entities.Concrete.BackgroundJob> jobs)
        {
            const string AssemblySchedulers = "AssemblySchedulers";

            if (_memoryCache.TryGetValue(AssemblySchedulers, out List<JobModel> result)) return result;

            var assembly = Assembly.GetExecutingAssembly();
            var resultJobs = assembly.GetTypes()
                                        .Where(t => typeof(IRecurringJob).IsAssignableFrom(t) &&
                                                    t.IsClass &&
                                                    jobs.Select(s => s.JobName).Contains(t.Name))
                                        .ToList();


            List<JobModel> selectedJobs = new List<JobModel>();
            foreach (var recurringJob in resultJobs)
            {
                var instance = (IRecurringJob)Activator.CreateInstance(recurringJob);
                if (instance != null)
                    selectedJobs.Add(new JobModel
                    {
                        JobName = recurringJob.Name,
                        Action = () => instance.Run()
                    });
            }

            _memoryCache.Set(AssemblySchedulers, selectedJobs);

            return selectedJobs;
        }

        private void ClearAllJobs(List<Entities.Concrete.BackgroundJob> jobs)
        {
            foreach (var job in jobs)
                RecurringJob.RemoveIfExists(job.Id.ToString());
        }
    }
}
