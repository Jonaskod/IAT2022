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
        
        public IActionResult Test(bool K1TEST, bool K2TEST, bool K3TEST, bool K4TEST)
        {
            var data = TempData["iddata"];
            var aids = _dbRepository.GetSingleProject(data.ToString());
            aids.Customer.K1 = K1TEST;
            aids.Customer.K2 = K2TEST;
            aids.Customer.K3 = K3TEST;
            aids.Customer.K4 = K4TEST;
            _dbRepository.UpdateProject(aids);
            //SKRIV TILL DB - UPPDATERA PROJEKT
            Model = new (_dbRepository);
            Model.Project = aids;
            TempData["mydata"] = aids.Id;
            return View(Model);
        }
        
        
    }
}
