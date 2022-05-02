using Microsoft.EntityFrameworkCore;
using UdemyProject.Models;

namespace UdemyProject.DataAccess
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DeviceClass> DeviceClasses { get; set; }
    }
}
