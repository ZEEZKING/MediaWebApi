using Microsoft.EntityFrameworkCore;
using System;

namespace Media_API_project.Entities.ApplicationDBContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Media> Media { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
