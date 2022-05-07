using Microsoft.AspNetCore.Mvc;
using UdemyProject.DataAccess;
using UdemyProject.DataAccess.Repository.IRepository;
using UdemyProject.Models;

namespace UdemyProject.Controllers
{
    public class DeviceClassController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeviceClassController(IUnitOfWork unitOfWork)
        {
        _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<DeviceClass> deviceclasslist = _unitOfWork.DeviceClass.GetAll();
            return View(deviceclasslist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeviceClass obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DeviceClass.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Device Class created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id is null || id ==0)
            { return NotFound(); }

            var categoryfromdb = _unitOfWork.DeviceClass.GetFirstOrDefault(u => u.Id == id);
            if (categoryfromdb is null)
                return NotFound();


            return View(categoryfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DeviceClass obj)
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
