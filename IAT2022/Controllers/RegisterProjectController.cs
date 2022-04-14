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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterProjectViewModel model) //Snygga till!
        {
            
            ProjectPoco projectPoco = new();
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
            return RedirectToAction("Index", "Assessment");
        }
    }
}
