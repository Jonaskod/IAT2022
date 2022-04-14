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
        private bool K1 { get; set; }
        private bool K2 { get; set; }
        private bool K3 { get; set; }
        private bool K4 { get; set; }


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
            return View(Model);
        }
        public IActionResult Indexx(ProjectInformationViewModel Project)
        {
            _dbRepository.UpdateProject(Project.Project);
            return View();
        }
        public IActionResult Test(bool K1TEST, bool K2TEST, bool K3TEST, bool K4TEST)
        {
            K1 = K1TEST;
            K2 = K2TEST;
            K3 = K3TEST;
            K4 = K4TEST;
            //SKRIV TILL DB - UPPDATERA PROJEKT
            return View();
        }
        
        
    }
}
