using System.ComponentModel.DataAnnotations;

namespace PitonProject.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        
        public int UserId { get; set; }

        public string? TaskDescription { get; set; }

        public DateOnly Deadline { get; set; }

        public bool IsCompleted { get; set;}

        public string? TaskType { get; set; }

     

    }
}
