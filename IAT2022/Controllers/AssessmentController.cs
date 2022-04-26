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
        public async Task<IActionResult> Customer()
        {
            var data = TempData["data"];
            var visited = TempData["visited"];
            ProjectInformationViewModel model = new(_dbRepository);
            model.Project = await _dbRepository.GetSingleProject(data.ToString());
            Model = model;
            //if (model.Project.Customer <= 0)
            //{
            //    return View(model);
            //}
            TempData["data"] = Model.Project.Id;//Skickar med tempdata mellan controllers
            return View(Model);
        }
        public async Task<IActionResult> Product()
        {
            var data = TempData["data"];
            ProjectInformationViewModel model = new(_dbRepository);
            model.Project = await _dbRepository.GetSingleProject(data.ToString());
            Model = model;
            //if (model.Project.Customer <= 0)
            //{
            //    return View(model);
            //}
            TempData["data"] = Model.Project.Id;//Skickar med tempdata mellan controllers
            return View(model);
        }
        public async Task<IActionResult> Business()
        {
            var model = await GetModel();
            TempData["data"] = model.Project.Id;//Skickar med tempdata mellan controllers
            return View(model);
        }
        public async Task<IActionResult> IPR()
        {
            var model = await GetModel();
            TempData["data"] = model.Project.Id;//Skickar med tempdata mellan controllers
            return View(model);
        }
        public async Task<IActionResult> Team()
        {
            var model = await GetModel();
            TempData["data"] = model.Project.Id;//Skickar med tempdata mellan controllers
            return View(model);
        }
        public async Task<IActionResult> Finance()
        {
            var model = await GetModel();
            TempData["data"] = model.Project.Id;//Skickar med tempdata mellan controllers
            return View(model);
        }
        public async Task<ProjectInformationViewModel> GetModel()
        {
            var data = TempData["data"];
            ProjectInformationViewModel model = new(_dbRepository);
            model.Project = await _dbRepository.GetSingleProject(data.ToString());
            return model;
        }

        public async void Test(List<bool> boolResultCustomer)
        {

            var data = TempData["data"];
            var project = await _dbRepository.GetSingleProject(data.ToString());
            var categories = await _dbRepository.GetCustomerQuestions();
            for (int i = 0; i < categories.Count; i++)
            {
                project.Customer[i].Result = boolResultCustomer[i];  
            }
            
            _dbRepository.UpdateProject(project);
            //SKRIV TILL DB - UPPDATERA PROJEKT
            TempData["data"] = project.Id;
        }
        public async void ProdutResult(List<bool> boolResultProduct)
        {
            var data = TempData["data"];
            var project = await _dbRepository.GetSingleProject(data.ToString());
            var categories = await _dbRepository.GetProductQuestions();
            for (int i = 0; i < categories.Count; i++)
            {
                project.Product[i].Result = boolResultProduct[i];
            }

            _dbRepository.UpdateProject(project);
            //SKRIV TILL DB - UPPDATERA PROJEKT
            TempData["data"] = project.Id;
        }
        public async void TeamResult(List<bool> boolResultTeam)
        {
            var data = TempData["data"];
            var project = await _dbRepository.GetSingleProject(data.ToString());
            var categories = await _dbRepository.GetProductQuestions();
            for (int i = 0; i < categories.Count; i++)
            {
                project.Product[i].Result = boolResultTeam[i];
            }

            _dbRepository.UpdateProject(project);
            //SKRIV TILL DB - UPPDATERA PROJEKT
            TempData["data"] = project.Id;
        }
        public async void IprResult(List<bool> boolResultIPR)
        {
            var data = TempData["data"];
            var project = await _dbRepository.GetSingleProject(data.ToString());
            var categories = await _dbRepository.GetProductQuestions();
            for (int i = 0; i < categories.Count; i++)
            {
                project.Product[i].Result = boolResultIPR[i];
            }

            _dbRepository.UpdateProject(project);
            //SKRIV TILL DB - UPPDATERA PROJEKT
            TempData["data"] = project.Id;
        }
        public async void FinanceResult(List<bool> boolResultFinance)
        {
            var data = TempData["data"];
            var project = await _dbRepository.GetSingleProject(data.ToString());
            var categories = await _dbRepository.GetProductQuestions();
            for (int i = 0; i < categories.Count; i++)
            {
                project.Product[i].Result = boolResultFinance[i];
            }

            _dbRepository.UpdateProject(project);
            //SKRIV TILL DB - UPPDATERA PROJEKT
            TempData["data"] = project.Id;
        }
        public async void BusinessResult(List<bool> boolResultBusiness)
        {
            var data = TempData["data"];
            var project = await _dbRepository.GetSingleProject(data.ToString());
            var categories = await _dbRepository.GetProductQuestions();
            for (int i = 0; i < categories.Count; i++)
            {
                project.Product[i].Result = boolResultBusiness[i];
            }

            _dbRepository.UpdateProject(project);
            //SKRIV TILL DB - UPPDATERA PROJEKT
            TempData["data"] = project.Id;
        }
    }
        
        
    
}
