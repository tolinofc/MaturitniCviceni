using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class LoginModel
    {
        [Required]
        [DisplayName("Jméno")]
        [StringLength(50,MinimumLength = 3)]
        [Range(0, 100)]
        [EmailAddress]
        [RegularExpression("^.{6,}$", ErrorMessage = "Foo")]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
