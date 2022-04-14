using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IAT2022.Data
{
    public class LoginDbContext : IdentityDbContext
    {
        private readonly DbContextOptions<LoginDbContext> _options;

        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
        {
            _options = options;
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
        }
    }
}
