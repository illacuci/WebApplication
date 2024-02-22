using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Models.Entities.Location;
using Models.Entities.Movements;


namespace Models.Entities.Centers
{
    public class Sites
    {
        [Key]
        [StringLength(4)]
        public string LogisticCenter { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        public int IdTown { get; set; }

        [Required]
        public int IdRegion { get; set; }

        [Required]
        public int IdSegment { get; set; }

        [Required]
        public string IdCenterCost { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string StreetName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int StreetNumber { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public DateTime CreatedTime { get; private set; }

        public DateTime ModificationTime { get; set; }

        [ForeignKey("IdRegion")]
        public Regions Region { get; set; }

        [ForeignKey("IdTown")]
        public Towns Town { get; set; }

        [ForeignKey("IdSegment")]
        public Segments Segment { get; set; }

        [ForeignKey("IdCenterCost")]
        public CentersCosts CentersCost { get; set; }
        public List<PurchaseOrders> PurchaseOrders { get; set; }

    }
}
