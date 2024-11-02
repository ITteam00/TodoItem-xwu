using MongoDB.Driver;
using System.Net;
using System.Text.Json;
using ToDoList.Api.Models;

namespace ToDoList.Api.ApiTests;

public class GetOneTodoItemTest : IClassFixture<CustomWebApplicationFactory>, IAsyncLifetime
{


    private readonly CustomWebApplicationFactory _factory;
    private readonly HttpClient _client;
    private IMongoCollection<ToDoItem> _mongoCollection;

    public GetOneTodoItemTest(CustomWebApplicationFactory factory) {
        _factory = factory;
        _client = _factory.CreateClient();

        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var mongoDatabase = mongoClient.GetDatabase("TodoItem");
        _mongoCollection = mongoDatabase.GetCollection<ToDoItem>("todos");
    }

    public async Task InitializeAsync()
    {
        // 清空集合
        await _mongoCollection.DeleteManyAsync(FilterDefinition<ToDoItem>.Empty);
    }

    // DisposeAsync 在测试完成后运行（如果有需要的话）
    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async void should_get_todo_by_given_id()
    {
        var todoItem = new ToDoItem
        {
            Id = "5f9a7d8e2d3b4a1eb8a7d8e2",
            Description = "Buy groceries",
            Done = false,
            Favorite = true
        };

        await _mongoCollection.InsertOneAsync(todoItem);

        var response = await _client.GetAsync("/api/v1/todoitems/5f9a7d8e2d3b4a1eb8a7d8e2");

        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();

        var returnedTodos = JsonSerializer.Deserialize<ToDoItem>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.NotNull(returnedTodos);
        Assert.Equal("Buy groceries", returnedTodos.Description);
        Assert.True(returnedTodos.Favorite);
        Assert.False(returnedTodos.Done);
    }


}