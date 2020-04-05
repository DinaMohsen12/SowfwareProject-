using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2_project.Models
{
    public class StudentModel
    {
        [Key]
        public short id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Full Name")]
        public string name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(25)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Age")]
        [Range(16, 25, ErrorMessage = "Your age has to be more than 16 and less than 25")]
        public short age { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string e_mail { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string phone { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        public string role { get; set; }

        public StudentModel()
        {
            role = "student";
        }

        public virtual ICollection<CourseModel> courseModel { get; set; }
    }
}