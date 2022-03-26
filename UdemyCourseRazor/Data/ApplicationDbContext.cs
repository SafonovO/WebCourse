using Microsoft.EntityFrameworkCore;
using UdemyCourseRazor.Model;

namespace UdemyCourseRazor.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Category> Categories { get; set; }

    }
}
