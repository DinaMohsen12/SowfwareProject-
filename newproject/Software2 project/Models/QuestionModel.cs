using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2_project.Models
{
    public class QuestionModel
    {
        [Key]
        public short id { get; set; }
        [Required]
        [Display(Name = "Question")]
        public string question { get; set; }
        [Required]
        [Display(Name = "Choice 1")]
        public string answer1 { get; set; }
        [Required]
        [Display(Name = "Choice 2")]
        public string answer2 { get; set; }
        [Display(Name = "Choice 3")]
        public string answer3 { get; set; }
        [Display(Name = "Choice 4")]
        public string answer4 { get; set; }
        [Display(Name = "Choice 5")]
        public string answer5 { get; set; }
        [Required]
        [Display(Name = "Right Answer")]
        public string rightAnswer { get; set; }

        [ForeignKey("CourseModel")]
        [Required]
        public short CourseId { get; set; }
        public virtual CourseModel CourseModel { get; set; }
    }
}