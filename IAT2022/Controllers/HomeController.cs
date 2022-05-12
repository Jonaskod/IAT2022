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
            _dbRepository.SeedCustomerQuestions();
            _dbRepository.SeedProductQuestions();
            _dbRepository.SeedBuisnessQuestions();
            _dbRepository.SeedFinanceQuestions();
            _dbRepository.SeedTeamQuestions();
            _dbRepository.SeedIprQuestions();
            _dbRepository.SeedTags();
        }
 
        public async Task<IActionResult> Index()
        {
            HomeViewModel home = new();
            var list = await _dbRepository.GetAllProjects(User.Identity.Name);
            home.Projects = list;
            return View(home);
        }


        
        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}