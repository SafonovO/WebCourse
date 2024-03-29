using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UdemyCourseRazor.Data;
using UdemyCourseRazor.Model;

namespace UdemyCourseRazor.Pages.Categories
{

    [BindProperties]
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
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

            if (Category.Name == Category.Description)
            {
                ModelState.AddModelError("category.Description", "Description should be different from Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                 _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
