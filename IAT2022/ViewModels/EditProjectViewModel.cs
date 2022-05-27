using IAT2022.Data.Poco;
using IAT2022.Repositories;
using System.ComponentModel.DataAnnotations;

namespace IAT2022.ViewModels
{
    public class EditProjectViewModel
    {
        private IDbRepository _dbRepository;
        public ProjectPoco Project { get; set; }
        public List<bool> TagsBool { get; set; }
        public List<ProjectTagsPoco> Tags { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string TypeOfProject { get; set; }
        [Required]
        public string Description { get; set; }
        public string Comment { get; set; }

        public EditProjectViewModel(IDbRepository dbRepository)
        {
           _dbRepository = dbRepository;
            _ = GetAll();
        }
        public async Task<List<ProjectTagsPoco>> GetAll()
        {
            var list = await _dbRepository.GetTags();
            Tags = list;
            return Tags;
        }
        public EditProjectViewModel()
        {

        }
        public bool Tagcheck(ProjectTagsPoco tag)
        {
            if (Project != null)
            {
                var projectTags = Project.Tags;
                foreach (var item in projectTags)
                {
                    if (item.Description == tag.Description)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    
    }
}
