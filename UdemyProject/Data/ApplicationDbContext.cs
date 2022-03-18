using Microsoft.EntityFrameworkCore;
using UdemyProject.Models;

namespace UdemyProject.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        
        }
        public DbSet<Category> Categories { get; set; }
    }
}
