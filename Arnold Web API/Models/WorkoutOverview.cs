#nullable disable

namespace Arnold_Web_API.Models
{
    public class WorkoutOverview
    {
        public string WorkoutName { get; set; }
        public string Duration { get; set; }
        public int? Difficulty { get; set; }
        public string CreatorName { get; set; }
        public string Exercise { get; set; }
    }
}
