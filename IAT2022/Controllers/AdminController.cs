using IAT2022.Data.Poco.QuestionsPoco;
using IAT2022.Repositories;
using IAT2022.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace IAT2022.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly IDbRepository _dbRepository;

        public AdminController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public IActionResult Index()
        {
            AdminViewModel adminView = new(_dbRepository);
            return View(adminView);
        }
        public async Task<IActionResult> SearchProjects(string search)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbRepository.SearchProjects(search);
                AdminViewModel viewModel = new(_dbRepository);
                viewModel.SearchResults = result;
                return View(viewModel);
            }
            return View();


        }
        public async Task<IActionResult> SearchTags(AdminViewModel model)
        {
            model.MyTags = await _dbRepository.ConvertTags(model.TagsBool);
            var result = await _dbRepository.SearchByTags(model.MyTags);
            model.SearchResults = result;
            return View(model);
        }
        #region SelectQuestionMethods
        public async Task<IActionResult> SelectCustomerQuestion(int id)
        {
            var qList = await _dbRepository.GetCustomerQuestions();
            var selectedQ = qList.Where(x => x.Id == id).FirstOrDefault();
            ChangeQuestionViewModel changeQuestionViewModel = new();
            changeQuestionViewModel.CustomerQuestion = selectedQ;
            return View("ChangeQuestion", changeQuestionViewModel);
        }
        public async Task<IActionResult> SelectProductQuestion(int id)
        {
            var pList = await _dbRepository.GetProductQuestions();
            var selectedP = pList.Where(x => x.Id == id).FirstOrDefault();
            ChangeQuestionViewModel changeQuestion = new();
            changeQuestion.ProductQuestion = selectedP;
            return View("ChangeQuestion", changeQuestion);
            
        }
        public async Task<IActionResult> SelectTeamQuestion(int id)
        {
            var tList = await _dbRepository.GetTeamQuestions();
            var selectedT = tList.Where(x => x.Id == id).FirstOrDefault();
            ChangeQuestionViewModel ChangeQuestion = new();
            ChangeQuestion.TeamQuestion = selectedT;
            return View("ChangeQuestion", ChangeQuestion);
        }
        public async Task<IActionResult> SelectIprQuestion(int id)
        {
            var iList = await _dbRepository.GetIPRQuestions();
            var selectedI = iList.Where(x => x.Id == id).FirstOrDefault();
            ChangeQuestionViewModel ChangeQuestion = new();
            ChangeQuestion.IprQuestion = selectedI;
            return View("ChangeQuestion", ChangeQuestion);
        }
        public async Task<IActionResult> SelectBusinessQuestion(int id)
        {
            var bList = await _dbRepository.GetBuisnessQuestions();
            var selectedB = bList.Where(x => x.Id == id).FirstOrDefault();
            ChangeQuestionViewModel ChangeQuestion = new();
            ChangeQuestion.BusinessQuestion = selectedB;
            return View("ChangeQuestion", ChangeQuestion);
        }
        public async Task<IActionResult> SelectFinanceQuestion(int id)
        {
            var fList = await _dbRepository.GetFinanceQuestions();
            var selectedF = fList.Where(x => x.Id == id).FirstOrDefault();
            ChangeQuestionViewModel ChangeQuestion = new();
            ChangeQuestion.FinanceQuestion = selectedF;
            return View("ChangeQuestion", ChangeQuestion);
        }
        #endregion
        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(ChangeQuestionViewModel model, int id)
        {
            if (model != null) 
            {
                if (model.CustomerQuestion != null)
                {
                    CustomerQuestionsPoco poco = new();
                    poco = model.CustomerQuestion;
                    poco.Id = id;
                    await _dbRepository.UpdateCustomerQuestion(poco);
                }
                else if (model.ProductQuestion != null)
                {
                    ProductQuestionsPoco poco = new();
                    poco = model.ProductQuestion;
                    poco.Id = id;
                    await _dbRepository.UpdateProductQuestion(poco);
                }
                else if (model.TeamQuestion != null)
                {
                    TeamQuestionsPoco poco = new();
                    poco = model.TeamQuestion;
                    poco.Id = id;
                    await _dbRepository.UpdateTeamQuestion(poco);
                }
                else if (model.IprQuestion != null)
                {
                    IprQuestionsPoco poco = new();
                    poco = model.IprQuestion;
                    poco.Id = id;
                    await _dbRepository.UpdateIprQuestion(poco);
                }
                else if (model.BusinessQuestion != null)
                {
                    BusinessQuestionsPoco poco = new();
                    poco = model.BusinessQuestion;
                    poco.Id = id;
                    await _dbRepository.UpdateBusinessQuestion(poco);
                }
                else if (model.FinanceQuestion != null)
                {
                    FinanceQuestionsPoco poco = new();
                    poco = model.FinanceQuestion;
                    poco.Id = id;
                    await _dbRepository.UpdateFinanceQuestion(poco);
                }
            }

            AdminViewModel admin = new (_dbRepository);
            return View("index", admin);
        }
       
        
        
    }
}
