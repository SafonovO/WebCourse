using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyProject.DataAccess.Repository.IRepository;
using UdemyProject.Models;

namespace UdemyProject.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChangesAsync();
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
