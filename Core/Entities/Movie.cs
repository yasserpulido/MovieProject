using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int Released { get; set; }
        public int Runtime { get; set; }
        public string Genre { get; set; }
        public string Plot { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
    }
}
