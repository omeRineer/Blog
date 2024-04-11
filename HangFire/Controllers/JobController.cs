using HangFire.Configuring;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangFire.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        readonly IGeneralSchedulerService _generalSchedulerService;

        public JobController(IGeneralSchedulerService generalSchedulerService)
        {
            _generalSchedulerService = generalSchedulerService;
        }

        [HttpGet("syncjobs")]
        public void SyncJobs()
        {
            _generalSchedulerService.Run();
        }
    }
}
