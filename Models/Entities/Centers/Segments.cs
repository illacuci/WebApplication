using System.ComponentModel.DataAnnotations;

namespace Models.Entities.Centers
{
    public class Segments
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [Required]
        public string NameSegment { get; set; }
        public List<Sites> Sites { get; set; }
    }
}
