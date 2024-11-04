using System.ComponentModel.DataAnnotations;
using TodoItems.Core;

namespace ToDoList.Api.Models
{
    public class ToDoItemDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(50)]
        public string Description { get; set; } = string.Empty;
        public bool Done { get; set; }
        public bool Favorite { get; set; }
        public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
        public static TodoItemDto MapToTodoItemDto(ToDoItemDto todoItemDto)
        {
            return new TodoItemDto
            {
                Id = todoItemDto.Id,
                Description = todoItemDto.Description,
                IsDone = todoItemDto.Done,
                IsFavorite = todoItemDto.Favorite,
                CreatedDate = todoItemDto.CreatedTime.DateTime,
                DueDate = null,
                TimeStamps = null
            };
        }
    }

}
