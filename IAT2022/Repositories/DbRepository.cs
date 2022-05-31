using IAT2022.Data;
using IAT2022.Data.Poco;
using IAT2022.Data.Poco.AboutUsInfoPoco;
using IAT2022.Data.Poco.InformationPoco;
using IAT2022.Data.Poco.QuestionsPoco;
using IAT2022.Data.Poco.SubCategoryPoco;
using IAT2022.GlobalClasses;
using Microsoft.EntityFrameworkCore;

namespace IAT2022.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly AppDbContext _appDbContext;

        public object HowToRegisterInformationPoco { get; private set; }

        public DbRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ProjectPoco> GetSingleProject(string id)
        {
            try
            {
                var project = _appDbContext.Projects.Where(x => x.Id == int.Parse(id)).Include(x => x.Tags).Include(x => x.Team).Include(x => x.Customer).FirstOrDefault();
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
            List<ProjectPoco>? list = _appDbContext.Projects?.Where(x => x.Owner == name).Include(x=> x.Tags).ToList();
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
            var hej = _appDbContext.Projects.Where((x) => x.Id == project.Id).Include(x => x.Business).FirstOrDefault();
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
        #region SearchMethods
        public async Task<List<ProjectPoco>> SearchProjects(string input)
        {
            var result = _appDbContext.Projects.Where(x => x.ProjectName.Contains(input)).Include(x => x.Customer).Include(x => x.Product).Include(x=>x.IPR).ToList();
            result = _appDbContext.Projects.Where(x=>x.ProjectName.Contains(input)).Include(x=>x.Business).Include(x=>x.Team).Include(x=>x.Finance).ToList();
            if (result.Any())
            {
                result = result.OrderByDescending(x => x.Created).ToList();
            }
            return result;
        }
        public async Task<List<ProjectPoco>> SearchByTags(List<TagPoco> projectTags)
        {
            
            var list = new List<ProjectPoco>();
            foreach (var tag in projectTags)
            {
                var result = _appDbContext.Projects.Include(x => x.Tags).Where(x=>x.Tags.Any(x=>x.Description==tag.Description)).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        if (!list.Contains(item))
                        {
                            list.Add(item);

                        }
                    }
                }
            }
            list = list.OrderByDescending(x => x.Created).ToList();
            return list;
        }
        #endregion
        #region Converters
        public async Task<List<TagPoco>> ConvertTags(List<bool> tagsBool)
        {
            List<TagPoco> projectTagsPocoList = new();
            var tags = await GetTags();
            for (int i = 0; i < tagsBool.Count; i++)
            {
                if (tagsBool[i])
                {
                    TagPoco tag = new()
                    {
                        Description = tags[i].Description
                    };
                    projectTagsPocoList.Add(tag);
                }
            }
            return projectTagsPocoList;
        }
        #endregion
        #region Question Updaters
        public async Task<AboutUsInfoPoco> UpdateAboutUsInformation(AboutUsInfoPoco question)
        {
            _appDbContext.Attach(question);
            _appDbContext.Entry(question).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return question;
        }
        public async Task<CustomerQuestionsPoco> UpdateCustomerQuestion(CustomerQuestionsPoco question)
        {
           
                _appDbContext.Attach(question);
                _appDbContext.Entry(question).State = EntityState.Modified;
                _appDbContext.SaveChanges();
                return question;
        }
        public async Task<ProductQuestionsPoco> UpdateProductQuestion(ProductQuestionsPoco question)
        {
            
            _appDbContext.Attach(question);
            _appDbContext.Entry(question).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return question;
        }
        public async Task<IprQuestionsPoco> UpdateIprQuestion(IprQuestionsPoco question)
        {
            
            _appDbContext.Attach(question);
            _appDbContext.Entry(question).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return question;
        }
        public async Task<TeamQuestionsPoco> UpdateTeamQuestion(TeamQuestionsPoco question)
        {
            
            _appDbContext.Attach(question);
            _appDbContext.Entry(question).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return question;
        }
        public async Task<BusinessQuestionsPoco> UpdateBusinessQuestion(BusinessQuestionsPoco question)
        {
            
            _appDbContext.Attach(question);
            _appDbContext.Entry(question).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return question;
        }
        public async Task<FinanceQuestionsPoco> UpdateFinanceQuestion(FinanceQuestionsPoco question)
        {
            
            _appDbContext.Attach(question);
            _appDbContext.Entry(question).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return question;
        }
        public async Task<HowToRegisterInformationPoco> UpdateHowToRegisterInformation(HowToRegisterInformationPoco information)
        {
            _appDbContext.Attach(information);
            _appDbContext.Entry(information).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return information;
        }
        #endregion
        #region Seed Methods
        public void SeedCustomerQuestions() 
        {
            if (!_appDbContext.CustomerQuestions.Any()) 
            {
                CustomerQuestionsPoco customerQuestionsPoco = new ();
                customerQuestionsPoco.QuestionDescription = "Du har identifierad ett behov eller problem.";
                customerQuestionsPoco.Level = 1;
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Du har undersökt vilka som har behovet.";
                customerQuestionsPoco.Level = 2;
                _appDbContext.CustomerQuestions.Add (customerQuestionsPoco);
                customerQuestionsPoco=new();
                customerQuestionsPoco.QuestionDescription = "Du har haft direkt kontakt med några behovsägare och ämnesexperter.";
                customerQuestionsPoco.Level = 3;
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Flera berörda personer har bekräftad behovet och vikten av att hitta en lösning.";
                customerQuestionsPoco.Level = 4;
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Du har etablerade relationer med några användare som visa intresse för din lösning.";
                customerQuestionsPoco.Level = 5;
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Du har en potential målkund som specificera vilka krav din lösning behöver uppfyller.";
                customerQuestionsPoco.Level = 5;
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Nyttan och fördelar av din lösning har verifierads genom första kundtester.";
                customerQuestionsPoco.Level = 6;
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Du har ett partnerskap som bidra med resurser till utveckling av din lösning";
                customerQuestionsPoco.Level = 6;
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Du har kundavtal och börjar med testförsäljning.initial product-market - fit";
                customerQuestionsPoco.Level = 7;
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Pilotkunder och relevanter intressenter deltar i utökad produkttestning";
                customerQuestionsPoco.Level = 7;
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Första produkterna säljs till några kunder.validerad product-market - fit";
                customerQuestionsPoco.Level = 8;
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);

                customerQuestionsPoco = new();
                customerQuestionsPoco.QuestionDescription = "Utbred försäjlning som kan skalas";
                customerQuestionsPoco.Level = 9;
                _appDbContext.CustomerQuestions.Add(customerQuestionsPoco);
                _appDbContext.SaveChanges();

            }

        }
        public void SeedHowToRegisterInformation()
        {
            if (!_appDbContext.HowToRegister.Any())
            {
                HowToRegisterInformationPoco poco = new()
                {
                    Title = "Information gällande registrering av information",
                    Paragraph= "Du kommer att få börja med att registrera två olika kategorier, det spelar ingen roll vilken kategori du väljer. När dessa två kategorier är besvarade kommer ytterligare två kategorier dyka upp. Det finns totalt sex olika kategorier som behöver besvaras för att kunna utvärdera din innovation. Du registrerar nivåer i kategorierna genom att klicka på de påståenden som stämmer överens med var du befinner dig i din utveckling av innovation. Du kan alltid välja att avbryta och spara din registrering genom att klcika på knappen 'Spara'. När du är klar kommer en sammanställning av dina svar visas och en visuell representation av vilka nivåer du befinner dig på i din utveckling."
                };
                _appDbContext.HowToRegister.Add(poco);
                _appDbContext.SaveChanges();
            }
        }
        public void SeedAboutUsInformation()
        {
            if (!_appDbContext.AboutUsInformation.Any())
            {
                AboutUsInfoPoco infoPoco = new()
                {
                    Title = "Working Title",
                    Paragraph = "Working Paragraph"
                };
                _appDbContext.AboutUsInformation.Add(infoPoco);
                _appDbContext.SaveChanges();
            }
        }
        public void SeedProductQuestions()
        {
            if (!_appDbContext.ProductQuestions.Any())
            {
                ProductQuestionsPoco questionPoco = new();

                questionPoco.QuestionDescription = "Tekniken eller methoden bygger på forskningsresultat";
                questionPoco.Level = 1;
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Ett produktkoncept har definerats ";
                questionPoco.Level = 2;
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Praktiska applikationer kan defineras";
                questionPoco.Level = 2;
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "”proof-of-concept” av kritiska egenskaper genom experimentella studier";
                questionPoco.Level = 3;
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new()
                {
                    QuestionDescription = "Temp # 4"
                };
                questionPoco.Level = 4;
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Tekniska komponenter har integrerats och fungera i laboratorium";
                questionPoco.Level = 4;
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new()
                {
                    QuestionDescription = "Temp # 5"
                };
                questionPoco.Level = 5;
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Tekniska komponenter har integrerats och fungera i en simulerad miljö";
                questionPoco.Level = 5;
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Realistisk prototyp testad i relevant miljö";
                questionPoco.Level = 6;
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Demonstration av systemprototyp i driftsmiljö ";
                questionPoco.Level = 7;
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Tekniklösningen är kvalitetssäkrad genom test och demonstration";
                questionPoco.Level = 8;
                _appDbContext.ProductQuestions.Add(questionPoco);
                questionPoco = new();
                questionPoco.QuestionDescription = "Tekniken tillämpas i dess slutliga form i driftsförhållanden";
                questionPoco.Level = 9;
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
                questionsPoco.Level = 1;
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Marknaden kan beskrivas på övergripande nivå";
                questionsPoco.Level = 2;
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Utkast till affärsmodellen i from av en canvas";
                questionsPoco.Level = 3;
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Marknadspotential och –storlek har kvantiferats";
                questionsPoco.Level = 3;

                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Fullständig affärtsmodel med specifikation av intäkter och kostnader";
                questionsPoco.Level = 4;
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Bedömd inträdeshinder och  konkurrensanalys utifrån differentiering";
                questionsPoco.Level = 4;
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Affärsmodellen har testats mot kunder för att verifiera hypoteser";
                questionsPoco.Level = 5;
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Detailjerad intäktsmodell med prissättningshypotheser och  tydliga intäktskällor";
                questionsPoco.Level = 5;
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Komplett affärsmodel verifierad genom testförsäljning";
                questionsPoco.Level = 6;
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Produkt-market-fit bevisat. Flera kunder visa tydlig betalningsvilja.";
                questionsPoco.Level = 7;
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Försäljningen visar att affärsmnodellen är hållbart, lönsam och skalbart.";
                questionsPoco.Level = 8;
                _appDbContext.BuisnessQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Verksamheten skalas upp med ökande och återkommande intäkter";
                questionsPoco.Level = 9;
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
                questionsPoco.Level = 1;
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Befintliga immateriella tillgångar har kartlagts";
                questionsPoco.Level = 2;
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Detailjerad beskrivning av viktiga immateriella tillgångar";
                questionsPoco.Level = 3;
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Inledande analys genom sökningar i databaser för patent och upphovsrätt";
                questionsPoco.Level = 3;
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Bekräftat om skydd är möjligt och för vad";
                questionsPoco.Level = 4;
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Beslut finns om vilka tillgångar som ska skyddas och varför (affärsrelevans).";
                questionsPoco.Level = 4;
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Utkast till IPR strategi för att använda tillgångar affärsstrategiskt finns.";
                questionsPoco.Level = 5;
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Första fullständiga patenansökan eller andra IP-registreringer inskickade.";
                questionsPoco.Level = 5;
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Positivt svar på inlämnad ansökan. IPR-stratgi implementerad. ";
                questionsPoco.Level = 6;
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Ansökningar för alla relevanta IPR har lämnats in";
                questionsPoco.Level = 7;
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "IPR används proaktivt för att stödja verksamhet. ";
                questionsPoco.Level = 8;
                _appDbContext.IPRQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Starkt immaterialrättsligt stöd och skydd. Eventuella patent beviljat och aktiv.";
                questionsPoco.Level = 9;
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
                questionsPoco.Level = 1;
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Hypothes finns om vilka kompetenser eller resurser som kan behövas.";
                questionsPoco.Level = 2;
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Befintliga och nödvändiga kompetenser är definerade";
                questionsPoco.Level = 3;
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "En engagerad projektledare och flera viktiga kompetenser finns på plats. ";
                questionsPoco.Level = 4;
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Rekrytering av personer med definerade kompetenser enligt en kravprofil.";
                questionsPoco.Level = 4;
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Grundteam med nödvändiga kompetenser finns . Alla lägger ner betydande tid.";
                questionsPoco.Level = 5;
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Teamet är anpassad til tydliga roller, gemensama mål, och tydig engagemang.";
                questionsPoco.Level = 5;
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Kompletterande, mångsidigt och engagerad team med alla nödvändiga resurser.";
                questionsPoco.Level = 6;
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Kultur och värderingar formas och används för att stödja teamutvecklingen";
                questionsPoco.Level = 7;
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Det finns en kompetent styrelse som används professionellt";
                questionsPoco.Level = 8;
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = " Ledning och VD på plats. Professionell användning av externt stöd.";
                questionsPoco.Level = 8;
                _appDbContext.TeamQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Högpresterande och välstrukturerat team som levererar över tid.";
                questionsPoco.Level = 9;
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
                questionsPoco.Level = 1;
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Inte specificerad hur mycket finansiering behövs och för vad.";
                questionsPoco.Level = 1;
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Definerad finansieringsbehov och alternativ för första milstolparna";
                questionsPoco.Level = 2;
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "En första, mjuk finansiering säkrad. ";
                questionsPoco.Level = 3;
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Affärsidé och inledande verifieringsplan finns";
                questionsPoco.Level = 3;
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Bra pitch och kort presentation av verksamheten på plats";
                questionsPoco.Level = 4;
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Investerarorienterad presentation och stödmaterial har testats";
                questionsPoco.Level = 5;
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Beslut om att söka privat riskkapital och inledande kontakter tagna";
                questionsPoco.Level = 6;
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Teamet kan presentera investeringen inklusive nyckerlområden ";
                questionsPoco.Level = 7;
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Diskussioner om villkor med interesserade inversterare pågår";
                questionsPoco.Level = 8;
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Företaget rimlig strukturerad i form av avtal, bokföring, dokumentation etc. ";
                questionsPoco.Level = 8;
                _appDbContext.FinanceQuestions.Add(questionsPoco);

                questionsPoco = new();
                questionsPoco.QuestionDescription = "Investeringen avslutat med erhållna pengar och relevant dokumentation";
                questionsPoco.Level = 9;
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
        #endregion
        #region Get Methods
        public async Task<string> GetHowToRegisterInformationGlobal()
        {
            if(HowToRegisterInformation.Title ==null && HowToRegisterInformation.Paragraph == null)
            {
                var information = await GetHowToRegisterInformation();
                HowToRegisterInformation.Title = information.Title;
                HowToRegisterInformation.Paragraph = information.Paragraph;
            }
            return "";
        }
        public async Task<AboutUsInfoPoco> GetAboutUsInformation()
        {
            var info = _appDbContext.AboutUsInformation.FirstOrDefault();
            return info;
        }
        public async Task<HowToRegisterInformationPoco> GetHowToRegisterInformation()
        {
            var info = _appDbContext.HowToRegister.FirstOrDefault();
            return info;
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
        #endregion
    }
}
