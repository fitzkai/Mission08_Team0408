using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0408.Models
{
    public class Redo
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string? DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public string? Category { get; set; }
        public bool? Completed { get; set; }
    }
}
