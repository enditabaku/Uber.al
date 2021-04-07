using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using UberDriver.Models;

namespace UberDriver.Concrete
{
    public class DrivingContext : DbContext
    {
        public DrivingContext() : base("name=DrivingContext") { } 
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}