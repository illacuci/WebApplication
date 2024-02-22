using Models.Entities.Centers;
using Models.Entities.Vendor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Movements
{
    public enum Movements
    {
        Compra,
        Transferencia
    }

    public class PurchaseOrders
    {
        [Key]
        [Range(1000000000, 5599999999)]
        public int PurchaseOrder { get; set; }
        [Required]
        public string LogisticCenter { get; set; }
        [Required]
        public string SupplierId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public Movements MovementType { get; set; }
        [ForeignKey("LogisticCenter")]
        public Sites Site { get; set; }
        [ForeignKey("SupplierId")]
        public Suppliers Supplier { get; set; }
        public List<PurchaseOrderDetails> Details { get; set; }
    }
}


