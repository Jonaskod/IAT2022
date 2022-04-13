using IAT2022.Data.Poco;
using IAT2022.Repositories;
using IAT2022.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IAT2022.Controllers
{
    public class AssessmentController : Controller
    {
        private readonly IDbRepository _dbRepository;

        public AssessmentController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public IActionResult Index()
        {
            var questions = _dbRepository.GetCustomerQuestions();
            var data = TempData["mydata"];
            ProjectInformationViewModel model = new();
            model.Project = _dbRepository.GetSingleProject(data.ToString());
            //if (model.Project.Customer <= 0)
            //{
            //    return View(model);
            //}
            return View(questions);
        }
        public void Test(bool k1)
        {
            
        }
        
        
    }
}
