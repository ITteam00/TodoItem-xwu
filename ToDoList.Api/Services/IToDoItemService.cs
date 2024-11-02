using ToDoList.Api.Models;

namespace ToDoList.Api.Services
{
    public interface IToDoItemService
    {
        Task CreateAsync(ToDoItemDto newToDoItem);
        Task<List<ToDoItemDto>> GetAsync();
        Task<ToDoItemDto?> GetAsync(string id);
        Task<bool> RemoveAsync(string id);
        Task ReplaceAsync(string id, ToDoItemDto updatedToDoItem);
    }
}