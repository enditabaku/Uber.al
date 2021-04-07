using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UberDriver.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        [Required(ErrorMessage = "You must enter your license's id.")]
        public DateTime StartDate { get; set; }
        public virtual ICollection<Supervisor> Supervisors { get; set; }
        public bool IsActive { get; set; }
    }
}