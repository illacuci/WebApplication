using System.ComponentModel.DataAnnotations;

namespace Models.Entities.Centers
{
    public class Regions
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [Required]
        public string NameRegion { get; set; }
        public List<Sites> Sites { get; set; }
    }
}
