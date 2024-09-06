using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentCourseFluentMVCApp.Validators;

namespace StudentCourseFluentMVCApp.Models
{
    public class Student
    {
        public virtual int Id { get; set; }

        [StringLength(10,ErrorMessage ="Length of Name Exceeds Specified Range")]
        [SpecialCharacterValidation]
        public virtual string Name { get; set; }

        [Required]
        [Range(18,24)]
        public virtual int Age { get; set; }

        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }

        public virtual Course Course { get; set; }

       
    }
}