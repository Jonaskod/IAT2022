﻿using IAT2022.Data.Poco;
using IAT2022.Data.Poco.QuestionsPoco;

namespace IAT2022.Repositories
{
    public interface IDbRepository
    {
        List<ProjectPoco>? GetAllProjects(string name);
        CustomerQuestionsPoco GetCustomerQuestions();
        ProjectPoco GetSingleProject(string id);
        ProjectPoco RegisterProject(ProjectPoco model);
        void SeedCustomerQuestions();
    }
}