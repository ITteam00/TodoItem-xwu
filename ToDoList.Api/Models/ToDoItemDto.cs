using System.ComponentModel.DataAnnotations;

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
    }
}
