using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.BackgroundJob
{
    public class BackgroundJobCreateDto
    {
        public string JobName { get; set; }
        public string Cron { get; set; }
        public bool IsActive { get; set; }
    }
}
