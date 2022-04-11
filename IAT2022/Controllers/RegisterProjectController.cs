using IAT2022.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IAT2022.Controllers
{
    public class RegisterProjectController : Controller
    {
        public RegisterProjectController()
        {

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterProjectViewModel model)
        {
            
            return View(model);
        }
    }
}
