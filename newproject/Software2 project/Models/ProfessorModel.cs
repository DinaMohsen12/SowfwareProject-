using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2_project.Models
{
    public class ProfessorModel
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
        [Range(25, 120)]
        public short age { get; set; }

        [Required]
        [Display(Name = "Salary")]
        public double salary { get; set; }

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

        public ProfessorModel()
        {
            role = "professor";
        }


        public virtual ICollection<CourseModel> courseModel { get; set; }
    }
}