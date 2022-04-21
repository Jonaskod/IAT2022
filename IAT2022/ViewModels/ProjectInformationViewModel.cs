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
        public ProjectTagsPoco ProjectTagsPoco { get; set; }
        public ProjectInformationViewModel(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
            //ProjectTagsPoco = _dbRepository.GetTags();
            CustomerQuestions = _dbRepository.GetCustomerQuestions();
        }
        //public string GetTagsForProject()
        //{
        //    if (Project.TagsBool.Tag1)do
        //    {
        //        return ProjectTagsPoco.Tag1;
        //    }
        //    return "";
        //}

        


      
       
    }
}
