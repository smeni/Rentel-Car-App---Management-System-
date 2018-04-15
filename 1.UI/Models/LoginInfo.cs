using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    public class LoginInfo
    {
        [Required]
        [Range(0, 10, ErrorMessage = "מה אתה עושה?")]
        [Display(Name = "דואר אלקטרוני")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "סיסמה")]
        [StringLength(10, MinimumLength = 4)]
        public string Password { get; set; }

    }
}