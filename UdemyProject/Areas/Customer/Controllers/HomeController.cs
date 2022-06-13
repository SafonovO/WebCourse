using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UdemyProject.DataAccess.Repository.IRepository;
using UdemyProject.Models;
using UdemyProject.Models.ViewModels;

namespace UdemyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties:"Category,DeviceClass");
            return View(productList);
        }

        public IActionResult Details(int id)
        {

            ShoppingCart cartObj = new()
            {
                Count=1,
                Product =  _unitOfWork.Product.GetFirstOrDefault(u => u.ID == id, includeProperties: "Category,DeviceClass"), 
            };
            return View(cartObj);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}