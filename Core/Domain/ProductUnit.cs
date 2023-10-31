using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class ProductUnit : BaseEntity
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Unit? Unit { get; set; }

    }
}
