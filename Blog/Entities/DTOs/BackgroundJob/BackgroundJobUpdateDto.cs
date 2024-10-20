namespace Entities.DTOs.BackgroundJob
{
    public class BackgroundJobUpdateDto
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string Cron { get; set; }
        public bool IsActive { get; set; }
    }
}
