using System.ComponentModel.DataAnnotations.Schema;

namespace IAT2022.Data.Poco
{
    public class ProjectPoco
    {
        public int Id { get; set; }
        public bool K1TEST { get; set; }
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? Owner { get; set; }
        public CustomerPoco? Customer { get; set; }
        public int? Product { get; set; }
        public int? IPR { get; set; }
        public int? Team { get; set; }
        public int? Buissness { get; set; }
        public int? Finance { get; set; }
        public string? ProjectType { get; set; }
        public List<CommentPoco>? Comments { get; set; }
        public List<ProjectTagsPoco> Tags { get; set; }
        //public TagsForProject? TagsForProject { get; set; } 
    
    }
}
