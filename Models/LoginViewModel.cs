using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UberDriver.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "This username doesn't exist.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Your password is incorrect.")]
        public string Password { get; set; }
    }
}