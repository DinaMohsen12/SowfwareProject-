using Software2_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software2_project.ViewModel
{
    public class CourseQuestionsViewModel
    {
        public List<QuestionModel> questions { get; set; }
        public CourseModel course { get; set; }
    }
}