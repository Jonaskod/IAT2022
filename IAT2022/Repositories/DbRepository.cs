using IAT2022.Data;
using IAT2022.Data.Poco;
using Microsoft.EntityFrameworkCore;

namespace IAT2022.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly AppDbContext _appDbContext;

        public DbRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ProjectPoco GetSingleProject(string id)
        {
            var project = _appDbContext.Projects.Where(x=>x.Id == int.Parse(id)).Include(x=>x.Comments).First();
            return project;
        }
        public List<ProjectPoco>? GetAllProjects(string name)
        {
            List<ProjectPoco>? list = _appDbContext.Projects?.Where(x => x.Owner == name).Include(x => x.Comments).ToList();
            if (list != null)
            {
                return list;
            }
            return null;
        }
        public ProjectPoco RegisterProject(ProjectPoco model)
        {
            try
            {
                _appDbContext.Projects?.Add(model);
                _appDbContext.SaveChanges();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
