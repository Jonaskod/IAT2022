﻿using IAT2022.Data.Poco.SubCategoryPoco;
using System.ComponentModel.DataAnnotations.Schema;

namespace IAT2022.Data.Poco
{
    public class ProjectPoco
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? Owner { get; set; }
        public List<CustomerPoco>? Customer { get; set; }
        public List<ProductPoco>? Product { get; set; }
        public List<IPRPoco>? IPR { get; set; }
        public List<TeamPoco>? Team { get; set; }
        public List<BusinessPoco>? Business { get; set; }
        public List<FinancePoco>? Finance { get; set; }
        public string? ProjectType { get; set; }
        public List<CommentPoco>? Comments { get; set; }
        public List<ProjectTagsPoco> Tags { get; set; }
        //public TagsForProject? TagsForProject { get; set; } 
    
    }
}
