using System.ComponentModel.DataAnnotations;

namespace AbbeyWeb.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int DisplayOreder { get; set; }
    }
}
