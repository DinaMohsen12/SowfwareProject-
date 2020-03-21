using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2_project.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter your name")]
        public string username { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        [StringLength(100, ErrorMessage = "should be at least 6 char", MinimumLength = 6)]
        public string password { get; set; }
    }
}