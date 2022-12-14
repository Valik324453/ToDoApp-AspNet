using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class Board
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        public virtual IEnumerable<Todo> Todos { get; set; } = new List<Todo>();
    }
}
