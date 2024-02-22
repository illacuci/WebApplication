using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrdersAPI.Application.DTO.ProductsDTO
{
    public class CategoriesCreateDTO
    {
        [StringLength(100, MinimumLength = 4)]
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
