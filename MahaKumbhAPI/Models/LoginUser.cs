using System.ComponentModel.DataAnnotations;

namespace MahaKumbhAPI.Models
{
    public class LoginUser
    {
        [MaxLength(100)]
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [MaxLength(100)]
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password is not strong enough (Should Contain atleast one UpperCase Letter, one LowerCase Letter, one digit, one special character and minlength should be 8")]

        public string Password { get; set; }
    }
}
