using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(20)]
        public string StudentName { get; set; }
        [EmailAddress]
        public string StudentEmail { get; set; }
        [MinLength(10)]
        public string StudentPhone { get; set; }
        public DateTime DOB { get; set; }
        public string Courses {  get; set; }
    }
}
