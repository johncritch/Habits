using System;
using System.ComponentModel.DataAnnotations;

namespace Habits.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int TaskID { get; set; } //Primary Key
        [Required]
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public bool Completed { get; set; }

        //Foriegn Key
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
