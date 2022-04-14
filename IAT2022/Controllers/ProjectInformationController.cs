using IAT2022.Repositories;
using IAT2022.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IAT2022.Controllers
{
    public class ProjectInformationController : Controller
    {
        private readonly IDbRepository _dbRepository;

        public ProjectInformationController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public IActionResult ProjectInformation(int id)
        {
            ProjectInformationViewModel projectInformationViewModel = new (_dbRepository);
            projectInformationViewModel.Project = _dbRepository.GetSingleProject(id.ToString());
            return View(projectInformationViewModel);
        }
    }
}
