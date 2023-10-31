namespace Core.ViewModels.Responses.Invoices
{
    public class InvoiceItemVM
    {
        public int? Id { get; set; }
        public int? InvoiceId { get; set; }
        public int? ProductUnitId { get; set; }
        public int? ProductId { get; set; }
        public int? UnitId { get; set; }
        public string? ProductName { get; set; }
        public string? UnitName { get; set; }
        public decimal? Price { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Total { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Net { get; set; }
    }
}
