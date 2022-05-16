using IAT2022.Data.Poco;
using IAT2022.Data.Poco.QuestionsPoco;
using IAT2022.Repositories;

namespace IAT2022.ViewModels
{
    public class ProjectInformationViewModel
    {
        private readonly IDbRepository _dbRepository;

        public ProjectPoco Project { get; set; }
        public colors[] Colors { get; set; } = (colors[])Enum.GetValues(typeof(colors));
        public List<CustomerQuestionsPoco> CustomerQuestions { get; set; }
        public List<BusinessQuestionsPoco> BusinessQuestions { get; set; }
        public List<IprQuestionsPoco> IPRQuestions { get; set; }
        public List<FinanceQuestionsPoco> FinanceQuestions { get; set; }
        public List<TeamQuestionsPoco> TeamQuestions { get; set; }
        public List<ProductQuestionsPoco> ProductQuestions { get; set; }
        public ProjectTagsPoco ProjectTagsPoco { get; set; }
        public ProjectInformationViewModel(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
            //ProjectTagsPoco = _dbRepository.GetTags();
            _ = GetAll();
            Colors = (colors[])Enum.GetValues(typeof(colors));
        }
        public enum colors {
            d58f22,
            e9940e,
            d5a723,
            e9b00c,
            d5bc1d,
            e8cb0f,
            dde23d,
            c1ee2d,
            cFFF00

        }
        public async Task<List<CustomerQuestionsPoco>> GetAll()
        {
            var list = await _dbRepository.GetCustomerQuestions();
            var product = await _dbRepository.GetProductQuestions();
            var ipr = await _dbRepository.GetIPRQuestions();
            var finance = await _dbRepository.GetFinanceQuestions();
            var team = await _dbRepository.GetTeamQuestions();
            var buisness = await _dbRepository.GetBuisnessQuestions();

            CustomerQuestions = list;
            BusinessQuestions = buisness;
            IPRQuestions = ipr;
            FinanceQuestions = finance; 
            TeamQuestions = team;
            ProductQuestions = product;

            return CustomerQuestions;
        }

        #region Converters for UI 
        public List<bool> ConvertCustomer(ProjectPoco poco)
        {
           List<bool> result = new List<bool>();
            if (poco != null)
            {
                result.Add(poco.Customer[0].Result);
                result.Add(poco.Customer[1].Result);
                result.Add(poco.Customer[2].Result);
                result.Add(poco.Customer[3].Result);
                if (poco.Customer[4].Result || poco.Customer[5].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                if (poco.Customer[6].Result || poco.Customer[7].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                if (poco.Customer[8].Result || poco.Customer[9].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                result.Add(poco.Customer[10].Result);
                result.Add(poco.Customer[11].Result);
            }
            return result;
        }
        public List<bool> ConvertProduct(ProjectPoco poco)
        {
            List<bool> result = new List<bool>();
            if (poco.Product != null)
            {
                result.Add(poco.Product[0].Result);
                if (poco.Product[1].Result || poco.Product[2].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                result.Add(poco.Product[3].Result);
                result.Add(poco.Product[4].Result);
                result.Add(poco.Product[5].Result);
                result.Add(poco.Product[6].Result);
                result.Add(poco.Product[7].Result);
                result.Add(poco.Product[8].Result);
                result.Add(poco.Product[9].Result);
            }
            return result;
        }
        public List<bool> ConvertBusiness(ProjectPoco poco)
        {
            List<bool> result = new();
            if(poco.Business != null)
            {
                result.Add(poco.Business[0].Result);
                result.Add(poco.Business[1].Result);
                if (poco.Business[2].Result || poco.Business[3].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                if (poco.Business[4].Result || poco.Business[5].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                if (poco.Business[6].Result || poco.Business[7].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                result.Add(poco.Business[8].Result);
                result.Add(poco.Business[9].Result);
                result.Add(poco.Business[10].Result);
                result.Add(poco.Business[11].Result);

            }
            return result;
        }
        public List<bool> ConvertIpr(ProjectPoco poco)
        {
            List<bool> result = new();
            if (poco != null)
            {
                result.Add(poco.IPR[0].Result);
                result.Add(poco.IPR[1].Result);
                if (poco.IPR[2].Result || poco.IPR[3].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                if (poco.IPR[4].Result || poco.IPR[5].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                if (poco.IPR[6].Result || poco.IPR[7].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                result.Add(poco.IPR[8].Result);
                result.Add(poco.IPR[9].Result);
                result.Add(poco.IPR[10].Result);
                result.Add(poco.IPR[11].Result);

            }
            return result;
        }
        public List<bool> ConvertTeam(ProjectPoco poco)
        {
            List<bool> result = new();
            if (poco.Team != null)
            {
                result.Add(poco.Team[0].Result);
                result.Add(poco.Team[1].Result);
                result.Add(poco.Team[2].Result);
                if (poco.Team[3].Result || poco.Team[4].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                if (poco.Team[5].Result || poco.Team[6].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                result.Add(poco.Team[7].Result);
                result.Add(poco.Team[8].Result);
                if (poco.Team[9].Result || poco.Team[10].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                result.Add(poco.Team[11].Result);

            }
            return result;
        }
        public List<bool> ConvertFinance(ProjectPoco poco)
        {
            List<bool> result = new();
            if (poco.Team != null)
            {
                if (poco.Finance[0].Result || poco.Finance[1].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                result.Add(poco.Finance[2].Result);
                if (poco.Finance[3].Result || poco.Finance[4].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                result.Add(poco.Finance[5].Result);
                result.Add(poco.Finance[6].Result);
                result.Add(poco.Finance[7].Result);
                result.Add(poco.Finance[8].Result);
                if (poco.Finance[9].Result || poco.Finance[10].Result)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
                result.Add(poco.Finance[11].Result);
               
                

            }
            return result;
        }

        #endregion

    }
}
