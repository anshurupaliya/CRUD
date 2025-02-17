using CRUD.Enums;
using CRUD.Models;
using CRUD.Models.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{

    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize(Policy = "NotAuthorized1")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        [Authorize(Policy = "NotAuthorized1")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = register.Email,
                    UserName = register.Email,
                    PersonName = register.PersonName,
                    PhoneNumber = register.Phone
                };
                IdentityResult result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    if (register.UserType == UserTypeEnum.Admin)
                    {
                        if (await _roleManager.FindByNameAsync(UserTypeEnum.Admin.ToString()) is null)
                        {
                            ApplicationRole role = new ApplicationRole()
                            {
                                Name = UserTypeEnum.Admin.ToString(),
                            };
                            await _roleManager.CreateAsync(role);
                        }
                        await _userManager.AddToRoleAsync(user, register.UserType.ToString());
                    }
                    else
                    {
                        if (await _roleManager.FindByNameAsync(UserTypeEnum.User.ToString()) is null)
                        {
                            ApplicationRole role = new ApplicationRole()
                            {
                                Name = UserTypeEnum.User.ToString(),
                            };
                            await _roleManager.CreateAsync(role);
                        }
                        await _userManager.AddToRoleAsync(user, register.UserType.ToString());
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Errors = result.Errors;
                    return View(register);
                }
            }
            else
            {
                return View();
            }
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize(Policy = "NotAuthorized1")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        [Authorize(Policy = "NotAuthorized1")]
        public async Task<IActionResult> Login(LoginDTO user, string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }

                }
            }
            else
            {
                return View(user);
            }
            return View();
        }

        [Route("[action]")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
