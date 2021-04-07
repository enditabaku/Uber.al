using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberDriver.Abstract;
using UberDriver.Models;

namespace UberDriver.Concrete
{
    public class UserRepository : IUserRepository
    {
        private DrivingContext context = new DrivingContext();
        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }


        public User FindUserByUsername(string username)
        {
            return context.Users.Where(u => u.Username == username).FirstOrDefault();
        }
    }
}