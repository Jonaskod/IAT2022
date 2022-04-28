using IAT2022.Data.Poco;
using IAT2022.Data.Poco.QuestionsPoco;

namespace IAT2022.Repositories
{
    public interface IDbRepository
    {
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
        void SeedBuisnessQuestions();
        void SeedCustomerQuestions();
        void SeedFinanceQuestions();
        void SeedIprQuestions();
        void SeedProductQuestions();
        void SeedTags();
        void SeedTeamQuestions();
        Task<ProjectPoco> UpdateProject(ProjectPoco project);
    }
}