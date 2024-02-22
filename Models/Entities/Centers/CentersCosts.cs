using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities.Centers
{
    public class CentersCosts
    {
        [Key]
        [StringLength(10)]
        public string LogisticCenter { get; set; }
        public List<Sites> Sites { get; set; }

    }
}
