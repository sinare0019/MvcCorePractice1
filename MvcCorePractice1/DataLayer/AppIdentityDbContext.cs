using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MvcCorePractice1.DomainClasses;

namespace MvcCorePractice1.DataLayer
{
    public class AppIdentityDbContext: IdentityDbContext
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options)
        {
        }
        public DbSet<Job> Jobss { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
    }
}
