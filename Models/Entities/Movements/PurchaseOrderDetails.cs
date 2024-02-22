using Models.Entities.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Movements
{
    public class PurchaseOrderDetails
    {
        [Key]
        public int DetalleOCId { get; set; }
        [Required]
        public string IdItem { get; set; }
        [Required]
        public string IdPackaging { get; set; }
        [Required]
        public int IdPurchaseOrder { get; set; }

        [ForeignKey("IdItem, IdPackaging")]
        public Packaging Packaging { get; set; }

        [ForeignKey("IdPurchaseOrder")]
        public PurchaseOrders PurchaseOrders { get; set; }
    }
}
