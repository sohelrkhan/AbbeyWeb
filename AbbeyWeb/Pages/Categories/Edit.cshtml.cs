using AbbeyWeb.Data;
using AbbeyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbeyWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
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
                if (Category.Name == Category.DisplayOrder.ToString())
                {
                    ModelState.AddModelError(string.Empty, "The Display Order can not exactly match the name.");
                }

                if (ModelState.IsValid)
                {
                     _db.Categories.Update(Category);
                    await _db.SaveChangesAsync();

                    TempData["success"] = "Category updated sucessfully.";

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
