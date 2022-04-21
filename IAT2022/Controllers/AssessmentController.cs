using IAT2022.Data.Poco;
using IAT2022.Repositories;
using IAT2022.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IAT2022.Controllers
{
    public class AssessmentController : Controller
    {
        private readonly IDbRepository _dbRepository;
        private ProjectInformationViewModel Model { get; set; }
        
        public AssessmentController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
            
        }
        public IActionResult Index()
        {
            var data = TempData["mydata"];
            ProjectInformationViewModel model = new(_dbRepository);
            model.Project = _dbRepository.GetSingleProject(data.ToString());
            Model = model;
            //if (model.Project.Customer <= 0)
            //{
            //    return View(model);
            //}
            TempData["iddata"] = Model.Project.Id;//Skickar med tempdata mellan controllers
            return View(Model);
        }

        
        public void Test(List<bool> boolResult)
        {

            var data = TempData["iddata"];
            var project = _dbRepository.GetSingleProject(data.ToString());
            var categories = _dbRepository.GetCustomerQuestions();
            for (int i = 0; i < categories.Count(); i++)
            {
                
                project.Customer[i].Result = boolResult[i];
            }
            
            _dbRepository.UpdateProject(project);
            //SKRIV TILL DB - UPPDATERA PROJEKT
            TempData["iddata"] = project.Id;
        }
        
        
    }
}
