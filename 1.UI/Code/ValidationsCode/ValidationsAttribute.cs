using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.UI_2.Code.ValidationsCode
{
    public class ValidationsAttribute : ValidationAttribute
    {
        public ValidationsAttribute()
        {
            ErrorMessage = "Password length must be even.";
        }

        public override bool IsValid(object value)
        {
            string password = value.ToString();
            return password.Length % 2 == 0;
         }
    }
}