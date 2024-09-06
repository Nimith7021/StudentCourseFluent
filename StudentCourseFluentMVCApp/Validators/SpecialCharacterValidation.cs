using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace StudentCourseFluentMVCApp.Validators
{
    public class SpecialCharacterValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string name = value.ToString();
                string pattern = @"[^a-zA-Z0-9]";
                bool checkMatch = Regex.IsMatch(name, pattern);
                if (checkMatch)
                    return new ValidationResult("Contains Special Characters");
                else
                    return ValidationResult.Success;
            }

            return new ValidationResult("Error");
        }
    }
}