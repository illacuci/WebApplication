using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Core.Entities.Base
{
    public abstract class BaseEntity <TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public virtual TKey Id { get; set; }

        [Required]
        public bool Active { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
