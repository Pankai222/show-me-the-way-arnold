using System.Collections.Generic;

namespace Arnold_Web_GraphAPI.Models
{
    public class Creator
    {
        public Creator(string firstname, string lastname, IEnumerable<IDictionary<string, object>>? workouts)
        {
            Firstname = firstname;
            Lastname = lastname;
            Workouts = workouts;
        }
        public string Firstname { get; set; }
        public string? Lastname { get; }
        public IEnumerable<IDictionary<string, object>>? Workouts { get; }
    }
}