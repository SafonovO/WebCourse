using Microsoft.AspNetCore.Mvc;
using UdemyProject.DataAccess;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "category created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id is null || id ==0)
            { return NotFound(); }

            var categoryfromdb = _db.Categories.Find(id);
            if(categoryfromdb is null)
                return NotFound();


            return View(categoryfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "category updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            { return NotFound(); }

            var categoryfromdb = _db.Categories.Find(id);
            if (categoryfromdb is null)
                return NotFound();


            return View(categoryfromdb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "category deleted successfully!";
                return RedirectToAction("Index");
          
        }

    }
}
