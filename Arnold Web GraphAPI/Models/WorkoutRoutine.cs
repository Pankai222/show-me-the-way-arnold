using System;
using System.Collections.Generic;

namespace Arnold_Web_GraphAPI.Models
{
    public class WorkoutRoutine
    {
        public WorkoutRoutine(string name, string duration, int? difficulty, DateTime? createDate, string? creator, IEnumerable<Exercise>? exercises = null)
        {
            Name = name;
            Duration = duration;
            Difficulty = difficulty;
            CreateDate = createDate;
            Creator = creator;
            Exercises = exercises;
        }
        
        public string Name { get; set; }
        public string Duration { get; set; }
        public int? Difficulty { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Creator { get; set; }
        public IEnumerable<Exercise>? Exercises { get; set; }
    }
}