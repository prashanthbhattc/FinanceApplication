using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fis.Ui.Areas.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fis.Ui.Areas.Common.Controllers
{
    public class LoginController : Controller
    {
       // UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        public LoginController( SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [Area("common")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName,
                   model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(nameof(Index),model);
           
        }
    }
}
