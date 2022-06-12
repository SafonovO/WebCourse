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
            productVM.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.ID == id);
            return View(productVM);
        }   
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

                if(obj.Product.ImageUrl is not null)
                {
                    var oldimagePath = Path.Combine(wwRootPath, obj.Product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldimagePath))
                    {
                        System.IO.File.Delete(oldimagePath);
                    }
                }
                
                using (var filestreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(filestreams);
                }
                obj.Product.ImageUrl = @"\Images\Products\" + fileName + extension;
            }
            if(obj.Product.ID == 0)
            {
                _unitOfWork.Product.Add(obj.Product);

            }
            else
            {
                _unitOfWork.Product.Update(obj.Product);

            }
            _unitOfWork.Save();
            TempData["success"] = "Product created successfully!";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.ID == id); 
        if (obj is null) {
            return Json(new { success = false, message = "Error while deleting" });
        }
        var oldimagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
        if (System.IO.File.Exists(oldimagePath))
        {
            System.IO.File.Delete(oldimagePath);
        }

        _unitOfWork.Product.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Deleted Successfully" });

    }
    #region API CALLS
    [HttpGet]

    public IActionResult getAll()
    {
        var productlist = _unitOfWork.Product.GetAll(includeProperties: "Category,DeviceClass");
        return Json(new { data = productlist });
    }
    #endregion
}

