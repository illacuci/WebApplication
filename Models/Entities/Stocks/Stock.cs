using Models.Entities.Centers;
using Models.Entities.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Stocks
{
    public class Stock
    {
        public string LogisticCenter { get; set; }
        public string IdProduct { get; set; }
        [Range(0, double.MaxValue)]
        public double Quantity { get; set; }

        [ForeignKey("LogisticCenter")]
        public Sites Sitio { get; set; }

        [ForeignKey("IdProduct")]
        public Items Item { get; set; }
    }

}
