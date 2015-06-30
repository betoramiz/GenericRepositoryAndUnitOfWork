using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryExample.Models;
using ExampleRepository.Data.Infraestrucure;
using RepositoryExample.Core;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RepositoryExample.Controllers
{
    [Authorize]
    public class SecurityController : Controller
    {
        UnitOfWork unit;
        private UserManager<UserProfile> userManager;

        public SecurityController()
        {
            unit = new UnitOfWork(new DatabaseContext());
            userManager = new UserManager<UserProfile>(new UserStore<UserProfile>(new DatabaseContext()));
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogIn(LoginVM user)
        {
            if(ModelState.IsValid)
            {
                var findedUser = userManager.Find("Alberto", "123456");
                if(findedUser != null)
                {
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var identity = userManager.CreateIdentity(findedUser, DefaultAuthenticationTypes.ApplicationCookie);

                    authenticationManager.SignOut();
                    authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties() { IsPersistent = true }, identity);

                    return RedirectToAction("Index", "Estate");
                }
                return View();
            }
            return View();
        }

        public ActionResult LogOut()
        {
            var AutheticationManager = HttpContext.GetOwinContext().Authentication;
            AutheticationManager.SignOut();
            return RedirectToAction("LogIn");
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(RegisterVM user)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var newUser = new UserProfile() { UserName = user.FullName, Email = user.Email };
                    var result = userManager.Create(newUser, user.Password);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Estate");
                    
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error);
                }
                catch(Exception ex)
                {
                    string err = ex.Message;
                }
            }
            
            return View();
        }
    }
}