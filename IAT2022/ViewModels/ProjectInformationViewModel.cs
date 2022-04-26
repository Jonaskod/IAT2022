using IAT2022.Data.Poco;
using IAT2022.Data.Poco.QuestionsPoco;
using IAT2022.Repositories;

namespace IAT2022.ViewModels
{
    public class ProjectInformationViewModel
    {
        private readonly IDbRepository _dbRepository;

        public ProjectPoco Project { get; set; }
        public List<CustomerQuestionsPoco> CustomerQuestions { get; set; }
        public List<BusinessQuestionsPoco> BusinessQuestions { get; set; }
        public List<IprQuestionsPoco> IPRQuestions { get; set; }
        public List<FinanceQuestionsPoco> FinanceQuestions { get; set; }
        public List<TeamQuestionsPoco> TeamQuestions { get; set; }
        public List<ProductQuestionsPoco> ProductQuestions { get; set; }
        public ProjectTagsPoco ProjectTagsPoco { get; set; }
        public ProjectInformationViewModel(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
            //ProjectTagsPoco = _dbRepository.GetTags();
            _ = GetAll();
        }
        public async Task<List<CustomerQuestionsPoco>> GetAll()
        {
            var list = await _dbRepository.GetCustomerQuestions();
            var product = await _dbRepository.GetProductQuestions();
            var ipr = await _dbRepository.GetIPRQuestions();
            var finance = await _dbRepository.GetFinanceQuestions();
            var team = await _dbRepository.GetTeamQuestions();
            var buisness = await _dbRepository.GetBuisnessQuestions();

            CustomerQuestions = list;
            BusinessQuestions = buisness;
            IPRQuestions = ipr;
            FinanceQuestions = finance; 
            TeamQuestions = team;
            ProductQuestions = product;

            return CustomerQuestions;
        }

        


      
       
    }
}
