using System.ComponentModel.DataAnnotations;

namespace Models.Entities.Products
{
    public class Brands
    {
        [Key]
        public string Id { get; set; }
        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        public List<Items> Items { get; set; }
    }
}
