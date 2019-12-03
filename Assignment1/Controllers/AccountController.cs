using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> signInManager;
        private UserManager<IdentityUser> userManager;

        public AccountController(
            SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            UserLogin login = new UserLogin();
            login.ReturnUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin login )
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(login.Name);
                
                if(user != null)
                {
                    await signInManager.SignOutAsync();
                    if((await signInManager.PasswordSignInAsync(user, login.Password, false, false)).Succeeded)
                    {
                        if(string.IsNullOrEmpty(login?.ReturnUrl))
                        {
                            return RedirectToAction("Home", "Recipe");
                        }
                        else
                        {
                            return Redirect(login?.ReturnUrl);
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password.");
            return View(login);
        }

        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

    }
}