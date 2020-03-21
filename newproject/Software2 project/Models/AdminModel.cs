using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2_project.Models
{
    public class AdminModel
    {
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
        [Phone]
        [Display(Name = "Phone Number")]
        public string phone { get; set; }
    }
}