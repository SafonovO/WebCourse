using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyProject.DataAccess.Repository.IRepository;
using UdemyProject.Models;

namespace UdemyProject.DataAccess.Repository
{
    public class DeviceClassRepository:Repository<DeviceClass>,IDeviceClassRepository
    {
        private ApplicationDbContext _db;

        public DeviceClassRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DeviceClass category)
        {
            _db.DeviceClasses.Update(category);
        }

    }
}
