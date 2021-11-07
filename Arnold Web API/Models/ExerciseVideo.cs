#nullable disable

namespace Arnold_Web_API.Models
{
    public class ExerciseVideo
    {
        public int IdexerciseVideos { get; set; }
        public string Video { get; set; }
        public int ExerciseIdexercise { get; set; }

        public virtual Exercise ExerciseIdexerciseNavigation { get; set; }
    }
}
