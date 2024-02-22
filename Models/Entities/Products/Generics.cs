using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Products
{
    public class Generics
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdCategory { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(2)]
        public string UMA { get; set; }
        [Required]
        public bool Active { get; set; }
        [ForeignKey("IdCategory")]
        public Categories Category { get; set; }
        public List<Items> Items { get; set; }
    }
}
