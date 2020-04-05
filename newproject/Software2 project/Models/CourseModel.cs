using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software2_project.Models
{
    public class CourseModel
    {

        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }

        public virtual ICollection<StudentModel> studentModels { get; set; }
        public virtual ICollection<ProfessorModel> professorModels { get; set; }


    }
}