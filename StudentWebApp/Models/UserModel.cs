using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentWebApp.Models
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
