using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UdemyCourseRazor.Data;
using UdemyCourseRazor.Model;

namespace UdemyCourseRazor.Pages.Categories
{

    [BindProperties]
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
           
                _db.Categories.Remove(Category);
                 _db.SaveChangesAsync();
                return RedirectToPage("Index");
        }
    }
}
