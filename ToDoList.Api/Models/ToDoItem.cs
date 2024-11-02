using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDoList.Api.Models
{
    [BsonIgnoreExtraElements]
    public class ToDoItem
    {
        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Description { get; set; } = string.Empty;
        public bool Done { get; set; }
        public bool Favorite { get; set; }

        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset CreatedTime { get; set; }
    }
}
