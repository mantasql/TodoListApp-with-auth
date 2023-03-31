using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList_auth.Models
{
    public class TodoList
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public virtual List<TodoEntry> TodoEntries { get; set; }
    }
}
