using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using UberDriver.Concrete;
using UberDriver.Models;

namespace UberDriver.Infrastructure
{
    public class FormsAuthProvider : IAuthProvider
    {
        DrivingContext context = new DrivingContext();
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
        public bool AuthenticateUser(string username, string password)
        {
            User user = context.Users.Where(u => u.Username == username).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            if (user.Password == password)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return true;
            }
            return false;
        }
        public bool SignOut()
        {

            FormsAuthentication.SignOut();
            return true;
        }

    }
}