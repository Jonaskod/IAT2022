using IAT2022.Data;
using IAT2022.Data.Poco;
using IAT2022.Repositories;
using IAT2022.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IAT2022.Controllers
{
    public class RegisterProjectController : Controller
    {
        private readonly IDbRepository _dbRepository;

        public RegisterProjectController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public IActionResult Register()
        {
            RegisterProjectViewModel registerProjectViewModel = new(_dbRepository);  
            return View(registerProjectViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterProjectViewModel model) //Snygga till!
        {
            
            ProjectPoco projectPoco = new();
            
            projectPoco.Tags = await Convert(model.TagsBool);
            projectPoco.Comments = new();
            projectPoco.ProjectName = model.Name;
            projectPoco.Description = model.Description;
            projectPoco.Owner=User.Identity.Name;
            projectPoco.ProjectType = model.TypeOfProject;
            
            if (model.Comment!=null)
            {
                CommentPoco commentPoco = new();
                commentPoco.Comment = model.Comment;
                projectPoco.Comments.Add(commentPoco);
            }
            _dbRepository.RegisterProject(projectPoco);
            TempData["data"] = projectPoco.Id;//Skickar med tempdata mellan controllers
            model.ProjectPoco = projectPoco;
            
            return View("ChoosePath", model);
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

        public async Task<IActionResult> ChoosePath()
        {
            var data = TempData["data"];
            if (data != null)
            {
                RegisterProjectViewModel model = new();
                model.ProjectPoco = await _dbRepository.GetSingleProject(data.ToString());
                TempData["data"] = model.ProjectPoco.Id;


                return View(model);
            }
            return View();
            
        }
        public IActionResult Customer(RegisterProjectViewModel model)
        {
            
            return RedirectToAction("Index", "Assessment");
        }
    }
}
