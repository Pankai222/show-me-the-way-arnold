using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Arnold_Web_DocumentAPI.Models
{
    public class Exercise
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Compound { get; set; }
        public string Category { get; set; }
    }
}