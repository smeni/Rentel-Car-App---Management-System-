using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2.BL.Validation
{
    [MetadataType(typeof(RegisterUserValidation))]
    public partial class User
    {
    }

    public partial class RegisterUserValidation
    {
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        //[Validations]//קיסטום של ולידציה המחייבת מספר זוגי של ספרות
        //[Range(1, int.MaxValue)]
        public int Password { get; set; }


        //[Range(0, 100, ErrorMessage = "מה אתה עושה?")]
        ////[GradeValidation]
        //public int Grade { get; set; }
    }
}
