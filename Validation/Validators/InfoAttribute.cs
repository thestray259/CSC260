using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Validation.Models; 

namespace Validation.Validators
{
    public class InfoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var info = (Info)validationContext.ObjectInstance;

            // age validation 
            if (info.Age <= 5) return new ValidationResult("Age cannot be below 5");

            // address validation - buggy
            if (info.StreetAddress == null && info.City == null && info.State == null && info.ZipCode == 0) return ValidationResult.Success;
            //else if (info.StreetAddress == null || info.City == null || info.State == null || info.ZipCode == 0) return new ValidationResult("You're missing some information. Please try again.");
            //else if (info.StreetAddress != null && info.City != null && info.State != null && info.ZipCode !=0) return ValidationResult.Success;
            else if (info.StreetAddress != null && (info.City == null || info.State == null || info.ZipCode == 0)) return new ValidationResult("You're missing some information. Please try again.");
            else if (info.City != null && (info.StreetAddress == null || info.State == null || info.ZipCode == 0)) return new ValidationResult("You're missing some information. Please try again.");
            else if (info.State != null && (info.StreetAddress == null || info.City == null || info.ZipCode == 0)) return new ValidationResult("You're missing some information. Please try again.");
            else if (info.ZipCode != 0 && (info.StreetAddress == null || info.City == null || info.State == null)) return new ValidationResult("You're missing some information. Please try again.");
            else return ValidationResult.Success;
        }
    }
}
