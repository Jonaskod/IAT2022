using IAT2022.Models;
using IAT2022.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using IAT2022.ViewModels;

namespace IAT2022.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbRepository _dbRepository;

        public HomeController(ILogger<HomeController> logger,IDbRepository dbRepository)
        {
            _logger = logger;
            _dbRepository = dbRepository;
            #region Seed methods that seeds if DB is empty
            _dbRepository.SeedCustomerQuestions();
            _dbRepository.SeedProductQuestions();
            _dbRepository.SeedBuisnessQuestions();
            _dbRepository.SeedFinanceQuestions();
            _dbRepository.SeedTeamQuestions();
            _dbRepository.SeedIprQuestions();
            _dbRepository.SeedTags();
            _dbRepository.SeedAboutUsInformation();
            _dbRepository.SeedHowToRegisterInformation();
            _ = _dbRepository.GetHowToRegisterInformationGlobal();
            #endregion
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel home = new();
            var list = await _dbRepository.GetAllProjects(User.Identity.Name);
            home.Projects = list;
            var name = User.Identity.Name;
            return View(home);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        public async Task<IActionResult> AboutUs()
        {
            var model = await _dbRepository.GetAboutUsInformation();
            return View(model);
        }
        public IActionResult DeleteProject(string id)
        {
            _dbRepository.DeleteProject(id);
            return RedirectToAction("Index", "Home");
        }
    }
}