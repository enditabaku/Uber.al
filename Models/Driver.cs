using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UberDriver.Models
{
    public class Driver
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Driver must correspond to a user.")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Driver must correspond to a user.")]
        public virtual User User { get; set; }
        [Required(ErrorMessage = "You must enter your license's id.")]
        public string LicenseId { get; set; }
        [Required(ErrorMessage = "You must enter your license's release date.")]
        public DateTime LicenseDate { get; set; }
        [Required(ErrorMessage = "You must enter your license's expiration date.")]
        public DateTime LicenseExpireDate { get; set; }
        public string OperatingArea { get; set; }
        [Required(ErrorMessage = "You must enter your date of birth.")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "You must enter your gender.")]
        public char Gender { get; set; }
        public string CarInfo { get; set; }
        [Required(ErrorMessage = "You must enter your car plate.")]
        public string Plate { get; set; }
        public int SupervisorId { get; set; }
        public virtual Supervisor Supervisor { get; set; }
        public bool IsActive { get; set; }
        public bool IsBusy { get; set; }
    }
}