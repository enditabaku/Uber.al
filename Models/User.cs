using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UberDriver.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username field cannot be empty.")]
        public string Username { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password field cannot be empty.")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$",
            ErrorMessage = "The password should be 8 characters or longer. Password should contain at least one uppercase letter, a number and a special character !@#$%^&*")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please rewrite your password to confirm.")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public bool IsDriver { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
    }
}