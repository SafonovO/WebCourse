using Microsoft.AspNetCore.Mvc;
using UdemyProject.Data;
using UdemyProject.Models;

namespace UdemyProject.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
        _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categorylist = _db.Categories;
            return View(categorylist);
        }
    }
}
