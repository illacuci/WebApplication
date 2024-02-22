using System.ComponentModel.DataAnnotations;

namespace APIRestGrpuL.Models.DTO.ProductsDTO
{
    public class CategoriesDTO
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
