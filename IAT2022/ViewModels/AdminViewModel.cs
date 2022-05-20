using IAT2022.Data.Poco.QuestionsPoco;
using IAT2022.Repositories;

namespace IAT2022.ViewModels
{
    public class AdminViewModel
    {
        private readonly IDbRepository _dbRepository;

        public List<CustomerQuestionsPoco>? CustomerQuestions { get; set; }
        public List<ProductQuestionsPoco>? ProductQuestions { get; set; }
        public List<IprQuestionsPoco>? IprQuestions { get; set; }
        public List<BusinessQuestionsPoco>? BusinessQuestions { get; set; }
        public List<TeamQuestionsPoco>? TeamQuestions { get; set; }
        public List<FinanceQuestionsPoco>? FinanceQuestions { get; set; }

        public AdminViewModel(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
            GetAllQuestions();
        }
        public async void GetAllQuestions()
        {
            CustomerQuestions = await _dbRepository.GetCustomerQuestions();
            ProductQuestions = await _dbRepository.GetProductQuestions();
            IprQuestions = await _dbRepository.GetIPRQuestions();
            BusinessQuestions = await _dbRepository.GetBuisnessQuestions();
            TeamQuestions = await _dbRepository.GetTeamQuestions();
            FinanceQuestions = await _dbRepository.GetFinanceQuestions();

        }

    }
}
