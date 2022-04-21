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
            
            projectPoco.Tags = Convert(model.TagsBool);
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
            TempData["mydata"] = projectPoco.Id;//Skickar med tempdata mellan controllers
            return View("ChoosePath", model);
        }
        public List<ProjectTagsPoco> Convert(List<bool> tagsBool)
        {
            List<ProjectTagsPoco> projectTagsPocoList = new List<ProjectTagsPoco>();
            var tags = _dbRepository.GetTags();
            for (int i = 0; i < tagsBool.Count(); i++)
            {
                if (tagsBool[i])
                {
                    projectTagsPocoList.Add(tags[i]);
                }
            }
            return projectTagsPocoList;
        }

        public IActionResult ChoosePath()
        {

            var data = TempData["iddata"];
            if (data != null)
            {
                RegisterProjectViewModel model = new();
                model.ProjectPoco = _dbRepository.GetSingleProject(data.ToString());
                TempData["mydata"] = model.ProjectPoco.Id;
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
