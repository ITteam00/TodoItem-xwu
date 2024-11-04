using ToDoList.Api.Models;

public class TodoStoreDatabaseSettings
{
    public required string ConnectionString { get; set; }

    public required string DatabaseName { get; set; }

    public required string TodoItemsCollectionName { get; set; }

}
