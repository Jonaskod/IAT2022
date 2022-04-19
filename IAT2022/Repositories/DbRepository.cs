using IAT2022.Data;
using IAT2022.Data.Poco;
using IAT2022.Data.Poco.QuestionsPoco;
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
            var project = _appDbContext.Projects.Where(x=>x.Id == int.Parse(id)).Include(x=>x.Comments).Include(x=>x.Customer).Include(x=>x.TagsBool).First();
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
                CustomerPoco customer = new CustomerPoco();
                model.Customer = customer;
                _appDbContext.Projects?.Add(model);
                _appDbContext.SaveChanges();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public ProjectPoco UpdateProject(ProjectPoco project)
        {
            _appDbContext.Projects.Update(project);
            _appDbContext.SaveChanges();
            return project;
        }
        public void SeedCustomerQuestions() 
        {
            if (!_appDbContext.CustomerQuestions.Any()) 
            {
                CustomerQuestionsPoco customerQuestionsPoco = new ();
                customerQuestionsPoco.K1 = "Du har identifierad ett behov eller problem.";
                customerQuestionsPoco.K2 = "Du har undersökt vilka som har behovet.";
                customerQuestionsPoco.K3 = "Du har haft direkt kontakt med några behovsägare och ämnesexperter.";
                customerQuestionsPoco.K4 = "Flera berörda personer har bekräftad behovet och vikten av att hitta en lösning.";
                customerQuestionsPoco.K5a = "Du har etablerade relationer med några användare som visa intresse för din lösning.";
                customerQuestionsPoco.K5b = "Du har en potential målkund som specificera vilka krav din lösning behöver uppfyller.";
                customerQuestionsPoco.K6a = "Nyttan och fördelar av din lösning har verifierads genom första kundtester.";
                customerQuestionsPoco.K6b = "Du har ett partnerskap som bidra med resurser till utveckling av din lösning";
                customerQuestionsPoco.K7a = "Du har kundavtal och börjar med testförsäljning.initial product-market - fit";
                customerQuestionsPoco.K7b = "Pilotkunder och relevanter intressenter deltar i utökad produkttestning";
                customerQuestionsPoco.K8a = "Första produkterna säljs till några kunder.validerad product-market - fit";
                customerQuestionsPoco.K8b = "Ökade struktuerade försäljningsinsatser  genomförs";
                customerQuestionsPoco.K9 = "Utbred försäjlning som kan skalas";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                _appDbContext.SaveChanges();

            }

        }
        public void SeedTags()
        {
            if (!_appDbContext.ProjectTags.Any())
            {
                ProjectTagsPoco projectTagsPoco = new ();
                projectTagsPoco.Tag1 = "Kommersiell";
                projectTagsPoco.Tag2 = "Icke kommersiellt";
                projectTagsPoco.Tag3 = "Mjukvara Applikation";
                projectTagsPoco.Tag4 = "Ny Teknologi";
                projectTagsPoco.Tag5 = "Ny metodik";
                _appDbContext.ProjectTags.Add(projectTagsPoco);
                _appDbContext.SaveChanges();

            }
        }
        public ProjectTagsPoco GetTags()
        {
            var tags = _appDbContext.ProjectTags.FirstOrDefault();
            return tags;
        }

        public CustomerQuestionsPoco GetCustomerQuestions()
        {
            var questions = _appDbContext.CustomerQuestions.FirstOrDefault();
            return questions;
        }
    }
}
