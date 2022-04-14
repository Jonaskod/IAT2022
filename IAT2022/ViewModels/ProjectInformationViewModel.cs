using IAT2022.Data.Poco;
using IAT2022.Data.Poco.QuestionsPoco;
using IAT2022.Repositories;

namespace IAT2022.ViewModels
{
    public class ProjectInformationViewModel
    {
        private readonly IDbRepository _dbRepository;

        public ProjectPoco Project { get; set; }
        public CustomerQuestionsPoco CustomerQuestions { get; set; }
        public ProjectInformationViewModel(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
            CustomerQuestions = _dbRepository.GetCustomerQuestions();
        }
      
       
    }
}
