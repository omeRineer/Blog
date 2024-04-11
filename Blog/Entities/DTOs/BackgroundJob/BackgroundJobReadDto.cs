using System;

namespace Entities.DTOs.BackgroundJob
{
    public class BackgroundJobReadDto
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string Cron { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
