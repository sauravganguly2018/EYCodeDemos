using System.ComponentModel.DataAnnotations;

namespace MahaKumbhAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [MaxLength(100)]
        [Required]

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Invalid FirstName")]

        public string FirstName { get; set; }
        [MaxLength(100)]
        [Required]

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Invalid LastName")]
        public string LastName { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        [MaxLength(100)]
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [Range(1000000000, 9999999999, ErrorMessage = "The Mobile Number must be of 10 digit")]
        public long MobileNumber { get; set; }
        [MaxLength(100)]
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$",ErrorMessage ="Password is not strong enough (Should Contain atleast one UpperCase Letter, one LowerCase Letter, one digit, one special character and minlength should be 8")]
        public string Password { get; set; }
    }
}
