using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.Models
{
    public class ToDoItemCreateRequest
    {
        [Required]
        [StringLength(50)]
        public string Description { get; set; } = string.Empty;
        public bool Done { get; set; }
        public bool Favorite { get; set; }

    }
}
