using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities.Products
{
    public class Packaging
    {
        [StringLength(2)]
        public string PresentacionId { get; set; }

        [Required]
        public string IdItem { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Count { get; set; }

        [ForeignKey("IdItem")]
        public Items Item { get; set; }
    }

}
