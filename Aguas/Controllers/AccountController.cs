using Aguas.Data.Entities;
using Aguas.Helpers;
using Aguas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Aguas.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;

        public AccountController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) 
            {
                return RedirectToAction("Dashboard", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userHelper.GetUserByEmailAsync(model.Username);
            if (user != null)
            {
                if (user.AdminAproved)
                {
                    if (ModelState.IsValid)
                    {
                        var result = await _userHelper.LoginAsync(model);
                        if (result.Succeeded)
                        {
                            if (this.Request.Query.Keys.Contains("ReturnUrl"))
                            {
                                return Redirect(this.Request.Query["ReturnUrl"].First());
                            }

                            return this.RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Waiting Aproval");
                    return View(model);
                }
            }

            this.ModelState.AddModelError(string.Empty, "Failed to login");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterNewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.Email);
                if (user == null)
                {
                    user = new User
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        FiscalNumber = model.FiscalNumber,
                        PhoneNumber = model.PhoneNumber,
                        UserName = model.Email,
                        WorkerAproved = false,
                        AdminAproved = false
                    };

                    var result = await _userHelper.AddUserNoPasswordAsync(user);
                    if (result != IdentityResult.Success)
                    {
                        ModelState.AddModelError(string.Empty, "The user couldn't be created.");
                        return View(model);
                    }

                    await _userHelper.AddUserToRoleAsync(user, "Client");
                }

                var isInRole = await _userHelper.IsUserInRoleAsync(user, "Client");
                if (!isInRole)
                {
                    await _userHelper.AddUserToRoleAsync(user, "Client");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
