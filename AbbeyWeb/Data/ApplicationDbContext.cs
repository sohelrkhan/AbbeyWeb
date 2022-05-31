using AbbeyWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace AbbeyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
    }
}
