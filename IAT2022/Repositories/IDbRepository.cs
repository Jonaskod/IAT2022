using IAT2022.Data.Poco;
using IAT2022.Data.Poco.QuestionsPoco;

namespace IAT2022.Repositories
{
    public interface IDbRepository
    {
        Task<List<ProjectPoco>> GetAllProjects(string name);
        Task<List<CustomerQuestionsPoco>> GetCustomerQuestions();
        Task<ProjectPoco> GetSingleProject(string id);
        Task<List<ProjectTagsPoco>> GetTags();
        Task<ProjectPoco> RegisterProject(ProjectPoco model);
        void SeedCustomerQuestions();
        void SeedTags();
        Task<ProjectPoco> UpdateProject(ProjectPoco project);
    }
}