using System.Collections.Generic;

namespace Arnold_Web_GraphAPI.Models
{
    public class Creator
    {
        public Creator(string firstname, string lastname, IEnumerable<Workout> workouts)
        {
            Firstname = firstname;
            Lastname = lastname;
            Workouts = workouts;
        }
        public string Firstname { get; }
        public string? Lastname { get; }
        public IEnumerable<Workout> Workouts { get; }
    }
}