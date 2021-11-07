using System.Collections.Generic;

#nullable disable

namespace Arnold_Web_API.Models
{
    public class Creator
    {
        public Creator()
        {
            Contacts = new HashSet<Contact>();
            WorkoutRoutines = new HashSet<WorkoutRoutine>();
        }

        public int IdCreator { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public ICollection<Contact> Contacts { get; set; }
        public ICollection<WorkoutRoutine> WorkoutRoutines { get; set; }
    }
}
