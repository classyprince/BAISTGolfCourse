using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.ViewModels.InputModels.Common
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Email Address:")]
        [StringLength(80)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password:")]
        [StringLength(600)]
        [MinLength(8, ErrorMessage = "Minimum of 8 characters")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
