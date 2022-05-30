using IAT2022.Data.Poco;
using IAT2022.Data.Poco.AboutUsInfoPoco;
using IAT2022.Data.Poco.QuestionsPoco;
using IAT2022.Data.Poco.SubCategoryPoco;

namespace IAT2022.Repositories
{
    public interface IDbRepository
    {
        Task<List<TagPoco>> ConvertTags(List<bool> tagsBool);
        Task DeleteProject(string id);
        Task<AboutUsInfoPoco> GetAboutUsInformation();
        Task<List<ProjectPoco>> GetAllProjects(string name);
        Task<List<BusinessQuestionsPoco>> GetBuisnessQuestions();
        Task<List<CustomerQuestionsPoco>> GetCustomerQuestions();
        Task<List<FinanceQuestionsPoco>> GetFinanceQuestions();
        Task<List<IprQuestionsPoco>> GetIPRQuestions();
        Task<List<ProductQuestionsPoco>> GetProductQuestions();
        Task<ProjectPoco> GetSingleProject(string id);
        Task<List<ProjectTagsPoco>> GetTags();
        Task<List<TeamQuestionsPoco>> GetTeamQuestions();
        Task<ProjectPoco> RegisterProject(ProjectPoco model);
        Task<List<ProjectPoco>> SearchByTags(List<TagPoco> projectTags);
        Task<List<ProjectPoco>> SearchProjects(string input);
        void SeedAboutUsInformation();
        void SeedBuisnessQuestions();
        void SeedCustomerQuestions();
        void SeedFinanceQuestions();
        void SeedIprQuestions();
        void SeedProductQuestions();
        void SeedTags();
        void SeedTeamQuestions();
        Task<AboutUsInfoPoco> UpdateAboutUsInformation(AboutUsInfoPoco question);
        Task<BusinessQuestionsPoco> UpdateBusinessQuestion(BusinessQuestionsPoco question);
        Task<CustomerQuestionsPoco> UpdateCustomerQuestion(CustomerQuestionsPoco question);
        Task<FinanceQuestionsPoco> UpdateFinanceQuestion(FinanceQuestionsPoco question);
        Task<IprQuestionsPoco> UpdateIprQuestion(IprQuestionsPoco question);
        Task<ProductQuestionsPoco> UpdateProductQuestion(ProductQuestionsPoco question);
        Task<ProjectPoco> UpdateProject(ProjectPoco project);
        Task<TeamQuestionsPoco> UpdateTeamQuestion(TeamQuestionsPoco question);
    }
}