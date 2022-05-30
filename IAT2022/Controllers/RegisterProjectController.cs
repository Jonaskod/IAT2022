using IAT2022.Data;
using IAT2022.Data.Poco;
using IAT2022.Data.Poco.SubCategoryPoco;
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
                if (model.Name == null)
                {
                     ModelState.AddModelError(string.Empty, "Du måste fylla i ett namn på ditt projekt");
                    RegisterProjectViewModel asd = new(_dbRepository);
                    return View(asd);

                }
           
                ProjectPoco projectPoco = new();
            
                projectPoco.Tags = await _dbRepository.ConvertTags(model.TagsBool);
                projectPoco.ProjectName = model.Name;
                projectPoco.Description = model.Description;
                projectPoco.Owner = User.Identity.Name;
                projectPoco.Created = DateTime.Now.ToShortDateString();
           
                _dbRepository.RegisterProject(projectPoco);
                TempData["data"] = projectPoco.Id;//Skickar med tempdata mellan controllers
                model.ProjectPoco = projectPoco;
            
                return View("ChoosePath", model);

            
            RegisterProjectViewModel registerProjectViewModel = new(_dbRepository);
            return View(registerProjectViewModel);
        }
        

        public async Task<IActionResult> ChoosePathCustomer()
        {
            
            var data = TempData["data"];
            if (data != null)
            {
                RegisterProjectViewModel model = new();
                model.ProjectPoco = await _dbRepository.GetSingleProject(data.ToString());
                _dbRepository.UpdateProject(model.ProjectPoco);
                TempData["data"] = model.ProjectPoco.Id;


                return View("ChoosePath", model);
            }
            return View(); 
        }
        public async Task<IActionResult> ChoosePathBusiness()
        {

            var data = TempData["data"];
            if (data != null)
            {
                RegisterProjectViewModel model = new();
                model.ProjectPoco = await _dbRepository.GetSingleProject(data.ToString());
                _dbRepository.UpdateProject(model.ProjectPoco);
                TempData["data"] = model.ProjectPoco.Id;


                return View("ChoosePath", model);
            }
            return View();
        }
        public async Task<IActionResult> ChoosePathFinance()
        {

            var data = TempData["data"];
            if (data != null)
            {
                RegisterProjectViewModel model = new();
                model.ProjectPoco = await _dbRepository.GetSingleProject(data.ToString());
                _dbRepository.UpdateProject(model.ProjectPoco);
                TempData["data"] = model.ProjectPoco.Id;


                return View("ChoosePath", model);
            }
            return View();
        }
        public async Task<IActionResult> ChoosePathIPR()
        {

            var data = TempData["data"];
            if (data != null)
            {
                RegisterProjectViewModel model = new();
                model.ProjectPoco = await _dbRepository.GetSingleProject(data.ToString());
                _dbRepository.UpdateProject(model.ProjectPoco);
                TempData["data"] = model.ProjectPoco.Id;


                return View("ChoosePath", model);
            }
            return View();
        }
        public async Task<IActionResult> ChoosePathProduct()
        {

            var data = TempData["data"];
            if (data != null)
            {
                RegisterProjectViewModel model = new();
                model.ProjectPoco = await _dbRepository.GetSingleProject(data.ToString());
                _dbRepository.UpdateProject(model.ProjectPoco);
                TempData["data"] = model.ProjectPoco.Id;


                return View("ChoosePath", model);
            }
            return View();
        }
        public async Task<IActionResult> ChoosePathTeam()
        {

            var data = TempData["data"];
            if (data != null)
            {
                RegisterProjectViewModel model = new();
                model.ProjectPoco = await _dbRepository.GetSingleProject(data.ToString());
                _dbRepository.UpdateProject(model.ProjectPoco);
                TempData["data"] = model.ProjectPoco.Id;


                return View("ChoosePath", model);
            }
            return View();
        }




        public IActionResult Customer(RegisterProjectViewModel model)
        {
            
            return RedirectToAction("Index", "Assessment");
        }
        
    }
}
