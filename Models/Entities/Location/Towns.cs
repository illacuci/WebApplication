using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Models.Entities.Centers;
using Models.Entities.Vendor;

namespace Models.Entities.Location
{
    public class Towns
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [Required]
        public string NameTown { get; set; }
        [Required]
        public int IdState { get; set; }
        [ForeignKey("IdState")]
        public States State { get; set; }
        public List<Suppliers> Suppliers { get; set; }
        public List<Sites> Sites { get; set; }

    }
}
