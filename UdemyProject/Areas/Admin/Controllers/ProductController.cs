using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyProject.DataAccess;
using UdemyProject.DataAccess.Repository.IRepository;
using UdemyProject.Models;
using UdemyProject.Models.ViewModels;

namespace UdemyProject.Controllers;

public class ProductController : Controller
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;

    public ProductController(IUnitOfWork unitOfWork,IWebHostEnvironment hostEnvironment)
    {
    _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
    }

    public IActionResult Index()
    {
       
        return View();
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
    public IActionResult Upsert(ProductVM obj, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            string wwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var uploads = Path.Combine(wwRootPath, @"Images\Products");
                var extension = Path.GetExtension(file.FileName);

                using (var filestreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(filestreams);
                }
                obj.Product.ImageUrl = @"\Images\Products\" + fileName + extension;
            }
            _unitOfWork.Product.Add(obj.Product);
            _unitOfWork.Save();
            TempData["success"] = "Product created successfully!";
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
    #region API CALLS
    [HttpGet]

    public IActionResult getAll()
    {
        var productlist = _unitOfWork.Product.GetAll();
        return Json(new { data = productlist });
    }
    #endregion
}

