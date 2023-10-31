using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Invoice : BaseEntity
    {
        public DateTime? Date {  get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? TotalDiscount { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Total { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? TaxPercent { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Net { get; set; }
        public ICollection<InvoiceItem>? InvoiceItems { get; set; }
    }
}
