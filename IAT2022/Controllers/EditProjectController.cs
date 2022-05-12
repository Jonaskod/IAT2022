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
            TempData["data"] = editProjectViewModel.Project.Id;
            return View(editProjectViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> EditProject(EditProjectViewModel model)
        {
            var data = TempData["data"];
            var project = await _dbRepository.GetSingleProject(data.ToString());
            project.Tags = await Convert(model.TagsBool);
            project.ProjectName = model.Name;
            project.Description = model.Description;    
            project.ProjectType = model.TypeOfProject;

            _dbRepository.UpdateProject(project);
            return RedirectToAction("Index", "Home");   


        }
        public async Task<List<ProjectTagsPoco>> Convert(List<bool> tagsBool)
        {
            List<ProjectTagsPoco> projectTagsPocoList = new();
            var tags = await _dbRepository.GetTags();
            for (int i = 0; i < tagsBool.Count; i++)
            {
                if (tagsBool[i])
                {
                    projectTagsPocoList.Add(tags[i]);
                }
            }
            return projectTagsPocoList;
        }

    }
}
