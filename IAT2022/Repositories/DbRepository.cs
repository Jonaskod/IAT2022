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
            List<ProjectPoco>? list = _appDbContext.Projects?.Where(x => x.Owner == name).Include(x => x.Comments).Include(x=> x.Tags).ToList();
            if (list != null)
            {
                list = list.OrderByDescending(x=>x.Id).ToList();
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
                    CustomerPoco customer = new();
                    model.Customer.Add(customer);
  
                }
                foreach (var item in _appDbContext.ProductQuestions)
                {
                    ProductPoco temp = new();
                    model.Product.Add(temp);
                }
                foreach (var item in _appDbContext.IPRQuestions)
                {
                    IPRPoco iPRPoco = new();
                    model.IPR.Add(iPRPoco);
                }
                foreach (var item in _appDbContext.BuisnessQuestions)
                {
                    BusinessPoco iBusinessPoco = new();
                    model.Business.Add(iBusinessPoco);
                }
                foreach (var item in _appDbContext.FinanceQuestions)
                {
                    FinancePoco iFinancePoco = new();
                    model.Finance.Add(iFinancePoco);
                }
                foreach (var item in _appDbContext.TeamQuestions)
                {
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
            var hej = _appDbContext.Projects.Where((x) => x.Id == project.Id).Include(x => x.Comments).Include(x => x.Business).FirstOrDefault();
            if (hej!=null)
            {
                hej = project;
            }
            _appDbContext.Attach(hej);
            _appDbContext.Entry(hej).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return project;
        }
        public async Task DeleteProject(string id)
        {
            var project = await GetSingleProject(id);
            _appDbContext.Projects.Attach(project);
            _appDbContext.Projects.Remove(project);
            _appDbContext.SaveChanges();
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
                customerQuestionsPoco.QuestionDescription = "Utbred försäjlning som kan skalas";
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                _appDbContext.SaveChanges();

            }

        }
        public void SeedProductQuestions()
        {
            if (!_appDbContext.ProductQuestions.Any())
            {
                ProductQuestionsPoco questionPoco = new();

                questionPoco.QuestionDescription = "Tekniken eller methoden bygger på forskningsresultat";
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Ett produktkoncept har definerats ";
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Praktiska applikationer kan defineras";
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "”proof-of-concept” av kritiska egenskaper genom experimentella studier";
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Tekniska komponenter har integrerats och fungera i laboratorium";
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Tekniska komponenter har integrerats och fungera i en simulerat miljö";
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Realistisk prototyp testad i relevant miljö";
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Demonstration av systemprototyp i driftsmiljö ";
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Tekniklösningen är kvalitetssäkrad genom test och demonstration";
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Tekniken tillämpas i dess slutliga form i driftsförhållanden";
                _appDbContext.ProductQuestions.Add(questionPoco);
                _appDbContext.SaveChanges();

            }
        }
        public void SeedBuisnessQuestions()
        {

            if (!_appDbContext.BuisnessQuestions.Any())
            {
                BusinessQuestionsPoco questionsPoco = new();
                questionsPoco.QuestionDescription = "Hypotes kring affärsmodell och möjliga applikationer";
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Marknaden kan beskrivas på övergripande nivå";
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Utkast till affärsmodellen i from av en canvas";
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Marknadspotential och –storlek har kvantiferats";

                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Fullständig affärtsmodel med specifikation av intäkter och kostnader";
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Bedömd inträdeshinder och  konkurrensanalys utifrån differentiering";
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Affärsmodellen har testats mot kunder för att verifiera hypoteser";
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Detailjerad intäktsmodell med prissättningshypotheser och  tydliga intäktskällor";
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Komplett affärsmodel verifierad genom testförsäljning";
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Produkt-market-fit bevisat. Flera kunder visa tydlig betalningsvilja.";
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Försäljningen visar att affärsmnodellen är hållbart, lönsam och skalbart.";
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Verksamheten skalas upp med ökande och återkommande intäkter";
                _appDbContext.BuisnessQuestions.Add(questionsPoco);
                _appDbContext.SaveChanges();

            }
        }
        public void SeedIprQuestions()
        {
            if (!_appDbContext.IPRQuestions.Any())
            {
                IprQuestionsPoco questionsPoco = new();
                questionsPoco.QuestionDescription = "Hypothes om eventuella immateriella tillgånger finns";
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Befintliga immateriella tillgångar har kartlagts";
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Detailjerad beskrivning av viktiga immateriella tillgångar";
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Inledande analys genom sökningar i databaser för patent och upphovsrätt";
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Bekräftat om skydd är möjligt och för vad";
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Beslut finns om vilka tillgångar som ska skyddas och varför (affärsrelevans).";
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Utkast till IPR strategi för att använda tillgångar affärsstrategiskt finns.";
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Första fullständiga patenansökan eller andra IP-registreringer inskickade.";
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Positivt svar på inlämnad ansökan. IPR-stratgi implementerad. ";
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Ansökningar för alla relevanta IPR har lämnats in";
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "IPR används proaktivt för att stödja verksamhet. ";
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Starkt immaterialrättsligt stöd och skydd. Eventuella patent beviljat och aktiv.";
                _appDbContext.IPRQuestions.Add(questionsPoco);
                _appDbContext.SaveChanges();
            }
        }

        public void SeedTeamQuestions()
        {
            if (!_appDbContext.TeamQuestions.Any())
            {
                TeamQuestionsPoco questionsPoco = new();
                questionsPoco.QuestionDescription = "En individ kopplad till idén.";
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Hypothes finns om vilka kompetenser eller resurser som kan behövas.";
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Befintliga och nödvändiga kompetenser är definerade";
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "En engagerad projektledare och flera viktiga kompetenser finns på plats. ";
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Rekrytering av personer med definerade kompetenser enligt en kravprofil.";
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Grundteam med nödvändiga kompetenser finns . Alla lägger ner betydande tid.";
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Teamet är anpassad til tydliga roller, gemensama mål, och tydig engagemang.";
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Kompletterande, mångsidigt och engagerad team med alla nödvändiga resurser.";
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Kultur och värderingar formas och används för att stödja teamutvecklingen";
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Det finns en kompetent styrelse som används professionellt";
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = " Ledning och VD på plats. Professionell användning av externt stöd.";
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Högpresterande och välstrukturerat team som levererar över tid.";
                _appDbContext.TeamQuestions.Add(questionsPoco);
                _appDbContext.SaveChanges();


            }
        }

        public void SeedFinanceQuestions()
        {
            if (!_appDbContext.FinanceQuestions.Any())
            {
                FinanceQuestionsPoco questionsPoco = new();
                questionsPoco.QuestionDescription = "Initial affärsidé med otydlig beskrivning på finansieringsbehov";
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Inte specificerad hur mycket finansiering behövs och för vad.";
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Definerad finansieringsbehov och alternativ för första milstolparna";
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "En första, mjuk finansiering säkrad. ";
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Affärsidé och inledande verifieringsplan finns";
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Bra pitch och kort presentation av verksamheten på plats";
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Investerarorienterad presentation och stödmaterial har testats";
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Beslut om att söka privat riskkapital och inledande kontakter tagna";
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Teamet kan presentera investeringen inklusive nyckerlområden ";
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Diskussioner om villkor med interesserade inversterare pågår";
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Företaget rimlig strukturerad i form av avtal, bokföring, dokumentation etc. ";
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Investeringen avslutat med erhållna pengar och relevant dokumentation";
                _appDbContext.FinanceQuestions.Add(questionsPoco);
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
                projectTagsPoco = new();
                projectTagsPoco.Description = "Process";

                _appDbContext.ProjectTags.Add(projectTagsPoco);
                projectTagsPoco = new();
                projectTagsPoco.Description = "Produkt";

                _appDbContext.ProjectTags.Add(projectTagsPoco);
                projectTagsPoco = new();
                projectTagsPoco.Description = "Tjänst";

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
        public async Task<List<ProductQuestionsPoco>> GetProductQuestions()
        {
            var questions = _appDbContext.ProductQuestions.ToList();


            return questions;
        }
        public async Task<List<IprQuestionsPoco>> GetIPRQuestions()
        {
            var questions = _appDbContext.IPRQuestions.ToList();


            return questions;
        }
        public async Task<List<TeamQuestionsPoco>> GetTeamQuestions()
        {
            var questions = _appDbContext.TeamQuestions.ToList();


            return questions;
        }
        public async Task<List<FinanceQuestionsPoco>> GetFinanceQuestions()
        {
            var questions = _appDbContext.FinanceQuestions.ToList();


            return questions;
        }
        public async Task<List<BusinessQuestionsPoco>> GetBuisnessQuestions()
        {
            var questions = _appDbContext.BuisnessQuestions.ToList();


            return questions;
        }
    }
}
