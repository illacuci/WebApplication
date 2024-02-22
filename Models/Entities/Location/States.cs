using System.ComponentModel.DataAnnotations;

namespace Models.Entities.Location
{
    public class States
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [Required]
        public string NameState { get; set; }
        public List<Towns> Towns { get; set; }
    }
}
