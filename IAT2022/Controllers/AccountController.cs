using IAT2022.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IAT2022.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            //seedRoles("Admin");
            



        }
        //public async Task<IActionResult> CreateAdmin(IdentityUser user) för att skapa admin
        //{
            



            
            
            
        //        var result = await _userManager.AddToRoleAsync(user, "Admin");
        //        await _signInManager.SignInAsync(user, isPersistent: false);

        //    return View();
        //}
        //public void seedRoles(string input)
        //{
        //    var admin = new IdentityRole(input);


        //    var roleExist =  _roleManager.RoleExistsAsync(admin.Name);
        //    if (!roleExist.Result)
        //    {
        //        var result = _roleManager.CreateAsync(admin);
        //    }



        //}
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Wrong password or accountname");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> RegisterAccount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAccount(RegisterAccountViewModel registerViewModel)
        {
            if (ModelState.IsValid) // Checks if modelstate is valid.
            {
                var user = new IdentityUser // Creates a user.
                {
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                    

                };

                 // Got error if you tried to log in directly after you logged out.
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded) // Checks if login succeded.
                {
                     // Got error if you tried to log in directly after you logged out.

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //await CreateAdmin(user); för att skapa admin
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors) // Errors = do this.
                {
                    ModelState.AddModelError("", error.Description);
                }
                ModelState.AddModelError("", "Inloggningen misslyckades");
            }

            return View(registerViewModel); // Returns the view with a viewmodel.
        }
    }
    

}
