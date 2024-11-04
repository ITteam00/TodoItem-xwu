using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDoList.Api.Services;

public class TodoItemPo{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }
    public bool IsFavorite { get; set; }
}