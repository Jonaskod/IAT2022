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
            if (boolResult != null)
            {
                project.Customer.K1 = boolResult[0];
                project.Customer.K2 = boolResult[1];
                project.Customer.K3 = boolResult[2];
                project.Customer.K4 = boolResult[3];
                if (boolResult[4] || boolResult[5])
                {
                    project.Customer.K5 = true;
                }
                if (boolResult[6] || boolResult[7])
                {
                    project.Customer.K6 = true;
                }
                if (boolResult[8] || boolResult[9])
                {
                    project.Customer.K7 = true;
                }

                if (boolResult[10] || boolResult[11])
                {
                    project.Customer.K8 = true;
                }
                project.Customer.K9 = boolResult[12];
            }
            

            _dbRepository.UpdateProject(project);
            //SKRIV TILL DB - UPPDATERA PROJEKT
            TempData["iddata"] = project.Id;
        }
        
        
    }
}
