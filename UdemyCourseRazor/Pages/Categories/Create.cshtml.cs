using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UdemyCourseRazor.Data;
using UdemyCourseRazor.Model;

namespace UdemyCourseRazor.Pages.Categories
{

    [BindProperties]
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public Category category { get; set; }
        public void OnGet()
        {    
        }

        public async Task<IActionResult> OnPost()
        {
           
               await _db.Categories.AddAsync(category);
               await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            
        }
    }
}
