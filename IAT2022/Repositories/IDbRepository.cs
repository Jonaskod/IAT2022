using IAT2022.Data.Poco;
using IAT2022.Data.Poco.QuestionsPoco;

namespace IAT2022.Repositories
{
    public interface IDbRepository
    {
        List<ProjectPoco>? GetAllProjects(string name);
        List<CustomerQuestionsPoco> GetCustomerQuestions();
        ProjectPoco GetSingleProject(string id);
        List<ProjectTagsPoco> GetTags();
        ProjectPoco RegisterProject(ProjectPoco model);
        void SeedCustomerQuestions();
        void SeedTags();
        ProjectPoco UpdateProject(ProjectPoco project);
    }
}