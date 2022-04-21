﻿using IAT2022.Data.Poco;
using IAT2022.Data.Poco.QuestionsPoco;
using Microsoft.EntityFrameworkCore;

namespace IAT2022.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<ProjectPoco>? Projects { get; set; }
        public DbSet<CustomerPoco> CustomerValue { get; set; }
        public  DbSet<CustomerQuestionsPoco> CustomerQuestions  { get; set; }
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