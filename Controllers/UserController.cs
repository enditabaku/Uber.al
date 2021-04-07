using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UberDriver.Abstract;
using UberDriver.Concrete;
using UberDriver.Infrastructure;
using UberDriver.Models;
using System.Data.Entity;

namespace UberDriver.Controllers
{
    public class UserController : Controller
    {

        DrivingContext context = new DrivingContext();
        IUserRepository repository = new UserRepository();
        IAuthProvider authProvider;
        public UserController(IAuthProvider auth, IUserRepository repo)
        {
            authProvider = auth;
            repository = repo;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.AuthenticateUser(model.Username, model.Password))
                {
                    User user = context.Users
                        .Include(u=> u.Role)
                        .Where(u => u.Username == model.Username).First();
                    if(user.Role.Name == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if(user.Role.Name == "Manager")
                    {
                        return RedirectToAction("Index", "Manager");
                    }
                    else if (user.Role.Name == "Supervisor")
                    {
                        return RedirectToAction("Index", "Supervisor");
                    }
                    else if (user.Role.Name == "Driver"){
                        return RedirectToAction("Index", "Driver");
                    }
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.Message = "Wrong username or password.";
                }
            }
            return View();
        }

        
        public ViewResult Register()
        {
            return View(new User() { 
                IsActive = true
            });
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                User existingUser = context.Users.Where(u => u.Username == user.Username).FirstOrDefault();
                User usedEmail = context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
                if (existingUser != null && usedEmail == null)
                {
                    ModelState.AddModelError(string.Empty, "This username is not available.");
                    return View(user);
                }
                else if (existingUser == null && usedEmail != null)
                {
                    ModelState.AddModelError(string.Empty, "This email/phone number is not available.");
                    return View(user);
                }
                else if (existingUser != null && usedEmail != null)
                {
                    ModelState.AddModelError(string.Empty, "This email/phone number and username are not available.");
                    return View(user);
                }
                if (user.IsDriver == true)
                {
                    try
                    {
                        var roleId = context.Roles.Where(role => role.Name == "Driver").FirstOrDefault().Id;
                        user.RoleId = roleId;
                        context.Users.Add(user);
                        context.SaveChanges();
                        return RedirectToAction("DriverSpecifications", user);
                    }
                    catch (Exception e)
                    {
                        return HttpNotFound();
                    }
                }
                else
                {
                    try
                    {
                        var roleId = context.Roles.Where(role => role.Name == "Customer").FirstOrDefault().Id;
                        user.RoleId = roleId;
                        context.Users.Add(user);
                        context.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception e)
                    {
                        return HttpNotFound();
                    }

                }
                
                
            }
            context.Users.Add(user);
            context.SaveChanges();
            if (authProvider.AuthenticateUser(user.Username, user.Password))
            {
                ViewBag.Message = "Your account was successfully created!";
            }
            else
            {
                ViewBag.Message = "Your account cannot be created.";
            }
            return View(user);
        }

        public ActionResult LogOut()
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie myCookie = new HttpCookie("cookieName");
            authProvider.SignOut();
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            return RedirectToAction("Login", "User");
        }
        public ViewResult DriverSpecifications(User user)
        {
            Driver driver = new Driver();
            driver.UserId = user.Id;
            return View(driver);
        }
        [HttpPost]
        public ActionResult DriverSpecifications(Driver driver)
        {
            //do stuff and checks
            if (authProvider.AuthenticateUser(driver.User.Username, driver.User.Password))
            {
                context.Drivers.Add(driver);
                context.SaveChanges();
                return View("Index", "Driver");
            }
            return View(driver);
        }
    }
}