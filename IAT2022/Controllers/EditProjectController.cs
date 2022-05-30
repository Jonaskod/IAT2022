using IAT2022.Data.Poco;
using IAT2022.Repositories;
using IAT2022.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IAT2022.Controllers
{
    public class EditProjectController : Controller
    {
        private readonly IDbRepository _dbRepository;
        public EditProjectController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<IActionResult> EditProject(int id)
        {
            EditProjectViewModel editProjectViewModel = new(_dbRepository);
            editProjectViewModel.Project = await _dbRepository.GetSingleProject(id.ToString());
            editProjectViewModel.Description = editProjectViewModel.Project.Description;
            TempData["data"] = editProjectViewModel.Project.Id;
            return View(editProjectViewModel);

        }
        [HttpPost]
        
        public async Task<IActionResult> EditProject(EditProjectViewModel model)
        {
            var data = TempData["data"];
            var project = await _dbRepository.GetSingleProject(data.ToString());
            project.Tags = await _dbRepository.ConvertTags(model.TagsBool);
            project.ProjectName = model.Name;
            project.Description = model.Description;

            _dbRepository.UpdateProject(project);
            return RedirectToAction("Index", "Home");   


        }
        

    }
}
