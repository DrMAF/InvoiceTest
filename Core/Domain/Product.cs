using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Product : BaseEntity
    {
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }
    }
}
