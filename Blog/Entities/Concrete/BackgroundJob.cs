using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class BackgroundJob : BaseEntity<long>, IEntity
    {
        public string JobName { get; set; }
        public string Cron { get; set; }
        public bool IsActive { get; set; }
    }
}
