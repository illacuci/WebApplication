using Models.Entities.Location;
using Models.Entities.Movements;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Vendor
{
    public class Suppliers
    {
        [Key]
        [StringLength(9)]
        public string Id { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 100)]
        public string BusinessName { get; set; }
        [Required]
        [StringLength(11)]
        public string CUIT { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int IdTown { get; set; }
        [ForeignKey("IdTown")]
        public Towns Town { get; set; }
        public List<PurchaseOrders> PurchaseOrders { get; set; }

    }
}
