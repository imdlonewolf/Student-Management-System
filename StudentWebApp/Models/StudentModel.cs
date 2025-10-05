using System.ComponentModel.DataAnnotations;

namespace StudentWebApp.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(20)]
        public string StudentName { get; set; }
        [Required]
        [EmailAddress]
        public string StudentEmail { get; set; }
        [Required]
        [StringLength(maximumLength: 10,MinimumLength =10)]
        public string StudentPhone { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Courses { get; set; }
    }
}
