using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Invoice : BaseEntity
    {
        [ForeignKey("Store")]
        public int? StoreId { get; set; }
        public DateTime? Date {  get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? TotalDiscount { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Total { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? TaxPercent { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Net { get; set; }
        public virtual ICollection<InvoiceItem>? InvoiceItems { get; set; }
        public virtual Store? Store { get; set; }
    }
}
