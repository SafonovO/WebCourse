using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyProject.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IDeviceClassRepository DeviceClass { get; }
        IProductRepository Product { get; }

        void Save();
        
    }
}
