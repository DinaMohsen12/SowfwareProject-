using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2_project.Models
{
    public class CourseModel
    {

        public short id { get; set; }
        [Required]
        [Display(Name ="Course Code")]
        public string code { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public string name { get; set; }

        public virtual ICollection<StudentModel> studentModels { get; set; }
        public virtual ICollection<ProfessorModel> professorModels { get; set; }


    }
}