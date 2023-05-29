using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FayrouzGlobitelAssignmentFullStack.Models;

namespace FayrouzGlobitelAssignmentFullStack.data
{
    public class SystemContext: IdentityDbContext<ApplicationUsers>
    {
        IConfiguration config;
        public SystemContext(IConfiguration _config)
        {
            config = _config;
        }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<Suggestion> Suggestions{ get; set; }
        //public DbSet<Sector> Sectors  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("GlobitelAssignment"));
            base.OnConfiguring(optionsBuilder);
        }

    }
}
