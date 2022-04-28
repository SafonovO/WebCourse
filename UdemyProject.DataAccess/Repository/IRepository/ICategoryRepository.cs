using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyProject.Models;

namespace UdemyProject.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : Irepository<Category>
    {
        void Update(Category category);
        void Save();
    }
}
