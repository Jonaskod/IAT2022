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
        
        public IActionResult Test(List<bool> kresultlist)
        {
            var data = TempData["iddata"];
            var aids = _dbRepository.GetSingleProject(data.ToString());
            aids.Customer.K1=kresultlist[0];
            aids.Customer.K2=kresultlist[1];
            aids.Customer.K3=kresultlist[2];
            aids.Customer.K4=kresultlist[3];
            if (kresultlist[4] || kresultlist[5])
            {
                aids.Customer.K5 = true;
            }
            else
            {
                aids.Customer.K5=false;
            }
            
            if (kresultlist[6] || kresultlist[7])
            {
                aids.Customer.K6 = true;
            }
            else
            {
                aids.Customer.K6=false;
            }
            
            if (kresultlist[8] || kresultlist[9])
            {
                aids.Customer.K7 = true;
            }
            else
            {
                aids.Customer.K7=false; 
            }
            
            if (kresultlist[10] || kresultlist[11])
            {
                aids.Customer.K8 = true;
            }
            else
            {
                aids.Customer.K8=false;
            }
            aids.Customer.K9=kresultlist[12];

            _dbRepository.UpdateProject(aids);
            //SKRIV TILL DB - UPPDATERA PROJEKT
            Model = new (_dbRepository);
            Model.Project = aids;
            TempData["mydata"] = aids.Id;
            return View(Model);
        }
        
        
    }
}
