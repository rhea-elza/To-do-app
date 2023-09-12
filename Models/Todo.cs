using System;
using System.ComponentModel.DataAnnotations;
namespace todo.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Item { get; set; }
    }
}