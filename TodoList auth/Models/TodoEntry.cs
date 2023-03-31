using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoList_auth.Models
{
    public class TodoEntry
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int TodoListId { get; set; }

        [JsonIgnore]
        public virtual TodoList TodoList { get; set; }
    }

    public enum State
    {
        Completed,
        InProgress,
        NotStarted
    }
}
