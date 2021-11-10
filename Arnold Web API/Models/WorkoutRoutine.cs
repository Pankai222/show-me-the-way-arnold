using System;
using System.Collections.Generic;

namespace Arnold_Web_API.Models
{
    public class WorkoutRoutine
    {
        public int IdworkoutRoutine { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int? Difficulty { get; set; }
        public int? CreatorIdCreator { get; set; }
        public DateTime? CreateDate { get; set; }
        
        public virtual ICollection<WorkoutRoutineHasExercise> WorkoutRoutineHasExercises { get; set; }
    }
}
