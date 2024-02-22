using OrdersAPI.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities.Products
{
    public class Categories : BaseEntity<int>
    {
        [StringLength(100, MinimumLength = 4)]
        [Required]
        public string Name { get; set; }
        public List<Generics> Generics { get; set; }
    }
}
