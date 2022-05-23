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
        public async Task<IActionResult> ProjectInformation(int id)
        {
            ProjectInformationViewModel projectInformationViewModel = new (_dbRepository);
            projectInformationViewModel.Project = await _dbRepository.GetSingleProject(id.ToString());
          
            if (projectInformationViewModel.Project.Owner == User.Identity.Name || User.IsInRole("Admin"))
            {
                TempData["data"] = projectInformationViewModel.Project.Id;
                return View(projectInformationViewModel);

            }
            else
            {
               return View();
            }
        }
        

    }
}
