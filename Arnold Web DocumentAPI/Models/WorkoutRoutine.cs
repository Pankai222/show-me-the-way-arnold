using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Arnold_Web_DocumentAPI.Models
{
    public class WorkoutRoutine
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int? Difficulty { get; set; }
        public int? Creator { get; set; }
        
    }
}