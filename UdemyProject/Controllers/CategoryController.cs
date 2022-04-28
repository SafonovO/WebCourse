using Microsoft.AspNetCore.Mvc;
using UdemyProject.DataAccess;
using UdemyProject.DataAccess.Repository.IRepository;
using UdemyProject.Models;

namespace UdemyProject.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
        _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categorylist = _unitOfWork.Category.GetAll();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "category created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id is null || id ==0)
            { return NotFound(); }

            var categoryfromdb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "category updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            { return NotFound(); }

            var categoryfromdb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (categoryfromdb is null)
                return NotFound();


            return View(categoryfromdb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj is null) { return NotFound(); }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "category deleted successfully!";
                return RedirectToAction("Index");
          
        }

    }
}
