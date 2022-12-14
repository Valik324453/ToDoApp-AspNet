using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public virtual Board? Board { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Field is required")]
        public string Title { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        
        [Display(Name ="Completed")]
        public bool Status { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}
