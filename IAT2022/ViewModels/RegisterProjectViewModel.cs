using System.ComponentModel.DataAnnotations;

namespace IAT2022.ViewModels
{
    public class RegisterProjectViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string TypeOfProject { get; set; }
        [Required]
        public string Description { get; set; }
        public string Comment { get; set; }
    }
}
