#nullable disable

namespace Arnold_Web_API.Models
{
    public class ExerciseHasMuscle
    {
        public int ExerciseIdexercise { get; set; }
        public int MuscleIdmuscle { get; set; }

        public Exercise ExerciseIdexerciseNavigation { get; set; }
        public Muscle MuscleIdmuscleNavigation { get; set; }
    }
}
