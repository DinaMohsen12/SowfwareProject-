using Software2_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software2_project.ViewModel
{
    public class ProfessorCourseViewModel
    {
        public ProfessorModel professor { get; set; }
        public List<CourseModel> courses { get; set; }
        public List<CourseModel> checkedCourses { get; set; }
    }
}