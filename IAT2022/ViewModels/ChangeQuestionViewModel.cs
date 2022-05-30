using IAT2022.Data.Poco.AboutUsInfoPoco;
using IAT2022.Data.Poco.InformationPoco;
using IAT2022.Data.Poco.QuestionsPoco;
using IAT2022.Repositories;

namespace IAT2022.ViewModels
{
    public class ChangeQuestionViewModel
    {
        
        public ProductQuestionsPoco? ProductQuestion { get; set; }
        public CustomerQuestionsPoco? CustomerQuestion { get; set; }
        public IprQuestionsPoco? IprQuestion { get; set; }
        public TeamQuestionsPoco? TeamQuestion { get; set; }
        public BusinessQuestionsPoco? BusinessQuestion { get; set; }
        public FinanceQuestionsPoco? FinanceQuestion { get; set; }
        public AboutUsInfoPoco? AboutUsInfo { get; set; }
        public HowToRegisterInformationPoco? HowToRegister { get; set; }

        
    }
}
