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
        public ProjectTagsPoco Tags { get; set; }
        public TagsBoolPoco TagsBool { get; set; }  
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
