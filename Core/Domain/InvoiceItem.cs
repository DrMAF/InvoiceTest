using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class InvoiceItem : BaseEntity
    {
        [ForeignKey("Invoice")]
        public int InvoiceId {  get; set; }
        [ForeignKey("ProductUnit")]
        public int ProductUnitId { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Quantity { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Total { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Discount { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Net { get; set; }
        public virtual Invoice? Invoice { get; set; }
        public virtual ProductUnit? ProductUnit { get; set; }
    }
}
