using IAT2022.Data.Poco;

namespace IAT2022.Repositories
{
    public interface IDbRepository
    {
        List<ProjectPoco>? GetAllProjects(string name);
        ProjectPoco GetSingleProject(string id);
        ProjectPoco RegisterProject(ProjectPoco model);
    }
}