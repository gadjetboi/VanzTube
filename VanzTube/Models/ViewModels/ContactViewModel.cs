using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VanzTube.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Description ="Email Address")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Your message is too long")]
        public string Comment { get; set; }
    }
}