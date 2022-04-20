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
        public RegisterProjectViewModel(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
            Tags = _dbRepository.GetTags();
            
        }
        public RegisterProjectViewModel()
        {

        }
        
    }
}
