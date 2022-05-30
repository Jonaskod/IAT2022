using IAT2022.Data.Poco;
using IAT2022.Data.Poco.AboutUsInfoPoco;
using IAT2022.Data.Poco.QuestionsPoco;
using Microsoft.EntityFrameworkCore;

namespace IAT2022.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<ProjectPoco>? Projects { get; set; }
        public DbSet<CustomerPoco> CustomerValue { get; set; }
        public DbSet<AboutUsInfoPoco> AboutUsInformation { get; set; }
        public DbSet<CustomerQuestionsPoco> CustomerQuestions  { get; set; }
        public DbSet<ProductQuestionsPoco> ProductQuestions { get; set; }
        public DbSet<BusinessQuestionsPoco> BuisnessQuestions { get; set; }
        public DbSet<IprQuestionsPoco> IPRQuestions { get; set; }
        public DbSet<TeamQuestionsPoco> TeamQuestions { get; set; }

        public DbSet<FinanceQuestionsPoco> FinanceQuestions { get; set; }

        public DbSet<ProjectTagsPoco> ProjectTags { get; set; } 

        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
