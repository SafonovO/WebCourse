using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyProject.DataAccess.Repository.IRepository;
using UdemyProject.Models;

namespace UdemyProject.DataAccess.Repository
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Product obj)
        {
            var objfromdatabase = _db.Products.FirstOrDefault(u=>u.ID == obj.ID);
            if(objfromdatabase is not null)
            {
                objfromdatabase.Name = obj.Name;
                objfromdatabase.ListPrice = obj.ListPrice;
                objfromdatabase.Price = obj.Price;
                objfromdatabase.Price5 = obj.Price5;
                objfromdatabase.Price10 = obj.Price10;
                objfromdatabase.Description = obj.Description;
                objfromdatabase.Manufacturer = obj.Manufacturer;
                objfromdatabase.CategoryId = obj.CategoryId;
                objfromdatabase.DeviceClassId = obj.DeviceClassId;
                if(obj.ImageUrl is not null)
                {
                    objfromdatabase.ImageUrl = obj.ImageUrl;
                }
            }
        }

            
    }
}
