using Software2_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software2_project.ViewModel
{
    public class QuestionCourseViewModel
    {
        public QuestionModel question { get; set; }
        public CourseModel course { get; set; }
    }
}