using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UberDriver.Models
{
    public class Supervisor
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        [Required(ErrorMessage = "You must enter your license's id.")]
        public DateTime StartDate { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public int? ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
        public bool IsActive { get; set; }
    }
}