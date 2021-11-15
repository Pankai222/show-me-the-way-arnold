using System;

#nullable disable

namespace Arnold_Web_API.Models
{
    public class WorkoutAudit
    {
        public WorkoutAudit()
        {
        }

        public int AuditId { get; set; }
        public int MadeBy { get; set; }
        public int ModifiedBy { get; set; }
        public string ActionType { get; set; }
        public DateTime MadeAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}