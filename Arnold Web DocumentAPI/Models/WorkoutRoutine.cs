namespace WebApplication.Models
{
    public class WorkoutRoutine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int? Difficulty { get; set; }
        public int? Creator { get; set; }
        
    }
}