using AbbeyWeb.Data;
using AbbeyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbeyWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _db.Categories.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Categories.Remove(Category);
                    await _db.SaveChangesAsync();

                    TempData["success"] = "Category deleted sucessfully.";

                    return RedirectToPage("Index");
                }

                return Page();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
