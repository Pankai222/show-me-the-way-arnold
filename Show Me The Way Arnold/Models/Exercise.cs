using System.Text.Json.Serialization;

namespace Show_Me_The_Way_Arnold.Models
{
    public class Exercise
    {
        [JsonPropertyName("idexercise")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Compound { get; set; }
    }
}