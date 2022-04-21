using IAT2022.Data;
using IAT2022.Data.Poco;
using IAT2022.Data.Poco.QuestionsPoco;
using IAT2022.Data.Poco.SubCategoryPoco;
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
        public async Task<ProjectPoco> GetSingleProject(string id)
        {
            try
            {
                var project = _appDbContext.Projects.Where(x => x.Id == int.Parse(id)).Include(x => x.Comments).Include(x => x.Tags).Include(x => x.Team).Include(x => x.Customer).FirstOrDefault();
                project = _appDbContext.Projects.Where(x => x.Id == int.Parse(id)).Include(x => x.Business).Include(x => x.Product).Include(x => x.Finance).Include(x => x.IPR).FirstOrDefault();

                return project;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<List<ProjectPoco>>? GetAllProjects(string name)
        {
            List<ProjectPoco>? list = _appDbContext.Projects?.Where(x => x.Owner == name).Include(x => x.Comments).ToList();
            if (list != null)
            {
                return list;
            }
            return null;
        }
        public async Task<ProjectPoco> RegisterProject(ProjectPoco model)
        {
            try
            {
                model.Customer = new();
                model.IPR = new();
                model.Business = new();
                model.Finance = new();
                model.Team = new();
                model.Product = new();
                foreach (var item in _appDbContext.CustomerQuestions)
                {
                    CustomerPoco question = new();
                    model.Customer.Add(question);
                    ProductPoco temp = new();
                    model.Product.Add(temp);
                    IPRPoco iPRPoco = new();
                    model.IPR.Add(iPRPoco);
                    BusinessPoco iBusinessPoco = new();
                    model.Business.Add(iBusinessPoco);
                    FinancePoco iFinancePoco = new();
                    model.Finance.Add(iFinancePoco);
                    TeamPoco iTeamPoco = new();
                    model.Team.Add(iTeamPoco);
                }
                _appDbContext.Projects?.Add(model);
                _appDbContext.SaveChanges();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public async Task<ProjectPoco> UpdateProject(ProjectPoco project)
        {
            var hej = _appDbContext.Projects.Where((x) => x.Id == project.Id).Include(x => x.Comments).Include(x => x.Customer).FirstOrDefault();
            if (hej!=null)
            {
                hej = project;
            }
            _appDbContext.Attach(hej);
            _appDbContext.Entry(hej).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return project;
        }
        public void SeedCustomerQuestions() 
        {
            if (!_appDbContext.CustomerQuestions.Any()) 
            {
                CustomerQuestionsPoco customerQuestionsPoco = new ();
                customerQuestionsPoco.QuestionDescription = "Du har identifierad ett behov eller problem.";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Du har undersökt vilka som har behovet.";
                _appDbContext.CustomerQuestions.Add (customerQuestionsPoco);
                customerQuestionsPoco=new();
                customerQuestionsPoco.QuestionDescription = "Du har haft direkt kontakt med några behovsägare och ämnesexperter.";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Flera berörda personer har bekräftad behovet och vikten av att hitta en lösning.";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Du har etablerade relationer med några användare som visa intresse för din lösning.";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Du har en potential målkund som specificera vilka krav din lösning behöver uppfyller.";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Nyttan och fördelar av din lösning har verifierads genom första kundtester.";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Du har ett partnerskap som bidra med resurser till utveckling av din lösning";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Du har kundavtal och börjar med testförsäljning.initial product-market - fit";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Pilotkunder och relevanter intressenter deltar i utökad produkttestning";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Första produkterna säljs till några kunder.validerad product-market - fit";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Ökade struktuerade försäljningsinsatser  genomförs";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Utbred försäjlning som kan skalas";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                _appDbContext.SaveChanges();

            }

        }
        public void SeedTags()
        {
            if (!_appDbContext.ProjectTags.Any())
            {
                ProjectTagsPoco projectTagsPoco = new ();
                projectTagsPoco.Description = "Kommersiell";
                _appDbContext.ProjectTags.Add(projectTagsPoco);

                projectTagsPoco = new();
                projectTagsPoco.Description = "Icke kommersiellt";
                _appDbContext.ProjectTags.Add(projectTagsPoco);

                projectTagsPoco = new();
                projectTagsPoco.Description = "Mjukvara Applikation";
                _appDbContext.ProjectTags.Add(projectTagsPoco);

                projectTagsPoco = new();
                projectTagsPoco.Description = "Ny Teknologi";
                _appDbContext.ProjectTags.Add(projectTagsPoco);

                projectTagsPoco = new();
                projectTagsPoco.Description = "Ny metodik";
                
                _appDbContext.ProjectTags.Add(projectTagsPoco);
                _appDbContext.SaveChanges();

            }
        }
        public async Task<List<ProjectTagsPoco>> GetTags()
        {
            var tags = _appDbContext.ProjectTags.ToList();
            return tags;
        }

        public async Task<List<CustomerQuestionsPoco>> GetCustomerQuestions()
        {
            var questions = _appDbContext.CustomerQuestions.ToList();
            return questions;
        }
    }
}
