using Microsoft.AspNetCore.Mvc;
using UdemyProject.DataAccess;
using UdemyProject.DataAccess.Repository.IRepository;
using UdemyProject.Models;

namespace UdemyProject.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository db)
        {
        _categoryRepository = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categorylist = _categoryRepository.GetAll();
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
                _categoryRepository.Add(obj);
                _categoryRepository.Save();
                TempData["success"] = "category created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id is null || id ==0)
            { return NotFound(); }

            var categoryfromdb = _categoryRepository.GetFirstOrDefault(u => u.Id == id);
            if (categoryfromdb is null)
                return NotFound();


            return View(categoryfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(obj);
                _categoryRepository.Save();
                TempData["success"] = "category updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            { return NotFound(); }

            var categoryfromdb = _categoryRepository.GetFirstOrDefault(u => u.Id == id);
            if (categoryfromdb is null)
                return NotFound();


            return View(categoryfromdb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _categoryRepository.GetFirstOrDefault(u => u.Id == id);
            if (obj is null) { return NotFound(); }
            _categoryRepository.Remove(obj);
                _categoryRepository.Save();
            TempData["success"] = "category deleted successfully!";
                return RedirectToAction("Index");
          
        }

    }
}
