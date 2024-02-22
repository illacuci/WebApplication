using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Products
{
    public class Items
    {
        [Key]
        [StringLength(7)]
        public string Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }
        [Required]
        public string BrandId { get; set; }
        [Required]
        public int GenericId { get; set; }
        [Required]
        public double Rounding { get; set; }
        [Required]
        public double ConversionFactor { get; set; }
        [Required]
        [StringLength(2)]
        public bool Active { get; set; }
        [ForeignKey("GenericId")]
        public Generics Generic { get; set; }
        [ForeignKey("BrandId")]
        public Brands Brand { get; set; }
        public List<Packaging> Packaging { get; set; }
    }
}
