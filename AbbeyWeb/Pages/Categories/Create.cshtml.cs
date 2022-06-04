using AbbeyWeb.Data;
using AbbeyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbeyWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public Category Category { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if(Category.Name == Category.DisplayOrder.ToString())
                {
                    ModelState.AddModelError(string.Empty, "The Display Order can not exactly match the name.");
                }

                if (ModelState.IsValid)
                {
                    await _db.Categories.AddAsync(Category);
                    await _db.SaveChangesAsync();

                    TempData["success"] = "Category created sucessfully.";
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
