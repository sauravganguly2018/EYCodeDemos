using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MahaKumbh.Models.Domain
{
    public class User
    {
        //[Key]
        //public int UserID { get; set; }
        //[MaxLength(100)]
        //[Required]
        //public string FirstName { get; set; }
        //[MaxLength(100)]
        //[Required]
        //public string LastName { get; set; }
        //[MaxLength(10)]
        //public string Gender { get; set; }
        //[MaxLength(100)]
        //[Required]
        //[EmailAddress(ErrorMessage = "Invalid email address.")]

        //public string Email { get; set; }
        //[MaxLength(15)]
        //public string MobileNumber { get; set; }
        //[MaxLength(100)]
        //[Required]
        //public string Password { get; set; }
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
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password is not strong enough (Should Contain atleast one UpperCase Letter, one LowerCase Letter, one digit, one special character and minlength should be 8")]
        public string Password { get; set; }
    }
}
