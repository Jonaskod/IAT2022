using IAT2022.Email;
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
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
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
                    

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var clink = Url.Action("ConfirmEmail", "Account", new { token, email = user.Email }, Request.Scheme).ToString();
                   
                   
                    
                    EmailSender emailSender = new EmailSender(user.Email, clink, "Verifiera din Epost", _configuration);
                    return View("VerifyEmail");

                }
                foreach (var error in result.Errors) // Errors = do this.
                {
                    ModelState.AddModelError("", error.Description);
                }
                ModelState.AddModelError("", "Inloggningen misslyckades");
            }

            return View(registerViewModel); // Returns the view with a viewmodel.
        }
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return View("Error");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return RedirectToAction("Login", "Account");
            
        }
        [HttpPost]
        public async Task<IActionResult> SendResetMail(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var clink = Url.Action("PasswordReset", "Account", new { token, email = user.Email }, Request.Scheme).ToString();
            EmailSender emailSender = new EmailSender(user.Email, clink, "Återställ Lösenord", _configuration);

            return View();
        }
        public async Task<IActionResult> PasswordReset(string token, string Email)
        {
            PasswordResetViewModel model = new PasswordResetViewModel();
            model.Token = token;
            model.Email = Email;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> PasswordReset(PasswordResetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

                var signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (signInResult.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }

            }

            return View();
        }

        public async Task<IActionResult> ResetMyPassword()
        {
            return View();
        }

        //public async Task<IActionResult> ResestPassword()
        //{
        //    string token = await _userManager.ResetPasswordAsync
        //}
    }
    
    

}
