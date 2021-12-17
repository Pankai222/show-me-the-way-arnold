using System;
using System.Collections.Generic;

namespace Arnold_Web_GraphAPI.Models
{
    public class Workout
    {
        public Workout(string name, string duration, int? difficulty, DateTime? createDate, IEnumerable<Exercise>? exercises = null)
        {
            Name = name;
            Duration = duration;
            Difficulty = difficulty;
            CreateDate = createDate;
            Exercises = exercises;
        }
        
        public string Name { get; }
        public string Duration { get; }
        public int? Difficulty { get; }
        public DateTime? CreateDate { get; }
        public IEnumerable<Exercise>? Exercises { get; }
    }
}