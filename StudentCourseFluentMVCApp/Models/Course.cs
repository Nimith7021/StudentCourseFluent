using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StudentCourseFluentMVCApp.Validators;

namespace StudentCourseFluentMVCApp.Models
{
    public class Course
    {
        public virtual int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Length of Name Exceeds Specified Range")]
        [SpecialCharacterValidation]
        public virtual string Name { get; set; }

        [Required]
        public virtual int Duration { get; set; }

        
        public virtual Student Student { get; set; }
    }
}