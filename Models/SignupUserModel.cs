using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnostic_Learning_Difficulties_Part2.Models
{
    public class SignupUserModel
    {
        [Required(ErrorMessage = "Please Enter your Fullname")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please Enter your Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter strong Password")]
        [Compare("confirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name = "confirmPassword")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
        private DateTime Birthday;
        [Required(ErrorMessage = "Please confirm your Birthday")]
        [DataType(DataType.Date)]
        public DateTime _Birthday
        {
            get { return Birthday.Date; }
            set { Birthday = value.Date; }
        }
        [Required(ErrorMessage = "Please confirm your Gender")]
        public string Gender { get; set; }
    }
}
