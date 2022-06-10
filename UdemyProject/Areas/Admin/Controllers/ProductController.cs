using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyProject.DataAccess;
using UdemyProject.DataAccess.Repository.IRepository;
using UdemyProject.Models;
using UdemyProject.Models.ViewModels;

namespace UdemyProject.Controllers
{
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
        _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> deviceclasslist = _unitOfWork.Product.GetAll();
            return View(deviceclasslist);
        }

   
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                DeviceClassList = _unitOfWork.DeviceClass.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id is null || id ==0)
            {
                
                return View(productVM); 
            }
            else
            {
                
            }


            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(DeviceClass obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DeviceClass.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Device class updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            { return NotFound(); }

            var categoryfromdb = _unitOfWork.DeviceClass.GetFirstOrDefault(u => u.Id == id);
            if (categoryfromdb is null)
                return NotFound();


            return View(categoryfromdb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.DeviceClass.GetFirstOrDefault(u => u.Id == id);
            if (obj is null) { return NotFound(); }
            _unitOfWork.DeviceClass.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Device class deleted successfully!";
                return RedirectToAction("Index");
          
        }

    }
}
