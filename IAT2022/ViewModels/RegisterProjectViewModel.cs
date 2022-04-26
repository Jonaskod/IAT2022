using IAT2022.Data.Poco;
using IAT2022.Repositories;
using System.ComponentModel.DataAnnotations;

namespace IAT2022.ViewModels
{
    public class RegisterProjectViewModel
    {
        private readonly IDbRepository _dbRepository;

        [Required]
        public string Name { get; set; }
        [Required]
        public string TypeOfProject { get; set; }
        [Required]
        public string Description { get; set; }
        public string Comment { get; set; }
        public List<ProjectTagsPoco> Tags { get; set; }
        public List<bool> TagsBool { get; set; }
        public ProjectPoco ProjectPoco { get; set; }
        public bool Visited { get; set; }
        public RegisterProjectViewModel(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
            _ = GetAll();
            
        }
        public RegisterProjectViewModel()
        {

        }
        public async Task<List<ProjectTagsPoco>> GetAll()
        {
            var list = await _dbRepository.GetTags();
            Tags = list;
            return Tags;
        }
        public bool IsVisited(bool input)
        {
            if (input)
            {
                return true;
            }
            return false;
        }
    }
}
