using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyProject.DataAccess.Repository.IRepository;

namespace UdemyProject.DataAccess.Repository
{
    public class UnitOfwork : IUnitOfWork
    { 
        private ApplicationDbContext _db;

        public UnitOfwork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            DeviceClass = new DeviceClassRepository(_db);
            Product = new ProductRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }

        public IDeviceClassRepository DeviceClass { get; private set; }

        public IProductRepository Product { get; private set; }
        
        
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
