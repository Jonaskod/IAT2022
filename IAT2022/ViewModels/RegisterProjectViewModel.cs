using IAT2022.Data.Poco;
using IAT2022.Data.Poco.InformationPoco;
using IAT2022.Repositories;
using SendGrid.Helpers.Mail;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IAT2022.ViewModels
{
    public class RegisterProjectViewModel
    {
        private readonly IDbRepository _dbRepository;

        [Required]
        public string Name { get; set; }
        
        public string TypeOfProject { get; set; }
        
        public string Description { get; set; }
        public string Comment { get; set; }
        public List<ProjectTagsPoco> Tags { get; set; }
        public List<bool> TagsBool { get; set; }
        public ProjectPoco ProjectPoco { get; set; }
        public HowToRegisterInformationPoco HowToRegister { get; set; }
        
        public bool Visited { get; set; }
        
        public RegisterProjectViewModel(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
            _ = GetAll();
            GetHowToRegisterInformation();
        }
        public RegisterProjectViewModel()
        {
           
        }
        public async Task<HowToRegisterInformationPoco> GetHowToRegisterInformation()
        {
            var aids = _dbRepository;
            return HowToRegister;
        }
        public async Task<List<ProjectTagsPoco>> GetAll()
        {
            var list = await _dbRepository.GetTags();
            Tags = list;
            return Tags;
        }
        
        public bool StepOne(ProjectPoco projectPoco)
        {
            var customer = projectPoco.Customer.Where(x => x.Result == true).ToList();
            var product = projectPoco.Product.Where(x => x.Result == true).ToList();
            if (customer.Count > 0 && product.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool StepTwo(ProjectPoco projectPoco)
        {

            var business = projectPoco.Business.Where(x => x.Result == true).ToList();
            var ipr = projectPoco.IPR.Where(x => x.Result == true).ToList();
            if (business.Count > 0 && ipr.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckIfAnswerd(ProjectPoco projectPoco, string input)
        {
            if (input == "Customer")
            {
                var customer = projectPoco.Customer.Where(x => x.Result == true).ToList();
                if (customer.Count > 0)
                {
                    return true;
                }
            }
            if (input == "Product")
            {
                var product = projectPoco.Product.Where(x => x.Result == true).ToList();
                if (product.Count > 0)
                {
                    return true;
                }
            }
            if (input == "IPR")
            {
                var Ipr = projectPoco.IPR.Where(x => x.Result == true).ToList();
                if (Ipr.Count > 0)
                {
                    return true;
                }
            }
            if (input == "Business")
            {
                var business = projectPoco.Business.Where(x => x.Result == true).ToList();
                if (business.Count > 0)
                {
                    return true;
                }
            }
            if (input == "Team")
            {
                var team = projectPoco.Team.Where(x => x.Result == true).ToList();
                if (team.Count > 0)
                {
                    return true;
                }
            }
            if (input == "Finance")
            {
                var finance = projectPoco.Finance.Where(x => x.Result == true).ToList();
                if (finance.Count > 0)
                {
                    return true;
                }
            }
            return false;
            
        }
        public bool InformationPush(ProjectPoco poco)
        {
            
            if (!CheckIfAnswerd(poco, "Customer") && !CheckIfAnswerd(poco, "Product"))
            {
                return true;
            }

            return false;
        }


    }
}
